using ElectroDepotClassLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.ExtensionMethods;
using Server.Models;

namespace Server.Controllers
{
    [Route("ElectronDepot/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        #region Create
        /// <summary>
        /// POST: ElectronDepot/Users/Create
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User? existingUserByUsername = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUserByUsername != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "A user with this username already exists." });
            }

            User? existingUserByEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUserByEmail != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "A user with this email already exists." });
            }

            User userToCreate = user.ToUser();

            _context.Users.Add(userToCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = userToCreate.ToDTO().ID }, userToCreate.ToDTO());
        }

        #endregion
        #region Read
        /// <summary>
        /// GET: ElectronDepot/Users
        /// </summary>
        /// <returns>All users in database</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            return Ok(await _context.Users.Select(x=>x.ToDTO()).ToListAsync());
        }

        /// <summary>
        /// GET: ElectronDepot/Users/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User with given ID</returns>
        [HttpGet("GetUserByID/{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { title = "not found", status = 404 });
            }

            return Ok(user.ToDTO());
        }

        [HttpGet("GetUserByEMail/{EMail}")]
        public async Task<ActionResult<UserDTO>> GetUser(string EMail)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x=>x.Email == EMail);

            if (user == null)
            {
                return NotFound(new { title = "not found", status = 404 });
            }

            return Ok(user.ToDTO());
        }

        [HttpGet("GetUserByUsername/{Username}")]
        public async Task<ActionResult<UserDTO>> GetUserByName(string Username)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
            {
                return NotFound(new { title = "not found", status = 404 });
            }

            return Ok(user.ToDTO());
        }

        /// <summary>
        /// GET: ElectronDepot/Users/{userId}/GetAllComponents
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>All components with their quantity for User with given ID</returns>
        [HttpGet("{userId}/GetAllComponents")]
        public async Task<IActionResult> GetComponentsWithQuantityForUser(int userId)
        {
            var componentsWithQuantity = await (from ownsComponent in _context.OwnsComponent
                                               join component in _context.Components on ownsComponent.ComponentID equals component.ComponentID
                                               where ownsComponent.UserID == userId
                                               select new
                                               {
                                                   ComponentID = component.ComponentID,
                                                   ComponentName = component.Name,
                                                   Manufacturer = component.Manufacturer,
                                                   Description = component.Description,
                                                   Quantity = ownsComponent.Quantity
                                               }).ToListAsync();

            if (componentsWithQuantity == null || !componentsWithQuantity.Any())
            {
                return NotFound(new { title = "No components found", status = 404, message = "No components found for the given user." });
            }

            return Ok(componentsWithQuantity);
        }
        #endregion
        #region Update
        /// <summary>
        /// PUT: ElectronDepot/Users/Create/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion
        #region Delete
        /// <summary>
        /// DELETE: ElectronDepod/Users/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
