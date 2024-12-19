using Server.Models;
using Server.Context;
using Server.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectroDepotClassLibrary.DTOs;

namespace Server.Controllers
{
    [Route("ElectroDepot/[controller]")]
    [ApiController]
    public class OwnsComponentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OwnsComponentsController(DatabaseContext context)
        {
            _context = context;
        }
        #region Create
        /// <summary>
        /// POST: ElectroDepot/OwnsComponents/Create
        /// </summary>
        /// <param name="ownsComponent"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<OwnsComponentDTO>> Create(CreateOwnsComponentDTO ownsComponent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User? existingUser = await _context.Users.FindAsync(ownsComponent.UserID);

            if (existingUser == null)
            {
                return BadRequest(new { title = "User not found", status = 400, message = "User with this ID doesn't exist." });
            }

            Component? existingComponent = await _context.Components.FindAsync(ownsComponent.ComponentID);

            if (existingComponent == null)
            {
                return BadRequest(new { title = "Component not found", status = 400, message = "Component with this ID doesn't exist." });
            }

            OwnsComponent createdOwnsComponent = ownsComponent.ToOwnComponent();

            _context.OwnsComponent.Add(createdOwnsComponent);
            await _context.SaveChangesAsync();

            return Ok(createdOwnsComponent.ToOwnsComponentDTO());
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/OwnsComponents/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OwnsComponentDTO>>> GetAllOwnsComponent()
        {
            return await _context.OwnsComponent.Select(x=>x.ToOwnsComponentDTO()).ToListAsync();
        }

        /// <summary>
        /// GET: ElectroDepot/OwnsComponents/GetByID/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<OwnsComponentDTO>> GetOwnComponentByID(int id)
        {
            var ownsComponent = await _context.OwnsComponent.FindAsync(id);

            if (ownsComponent == null)
            {
                return NotFound();
            }

            return ownsComponent.ToOwnsComponentDTO();
        }

        [HttpGet("GetAllUnusedComponents/{userID}")]
        public async Task<ActionResult<IEnumerable<OwnsComponentDTO>>> GetAllUnusedComponents(int userID)
        {
            // Does user exists
            User user = await _context.Users.FindAsync(userID);
            if(user == null)
            {
                return NotFound();
            }

            //var _context.ProjectComponents.GroupBy(x => x.ComponentID).Select(x=> new { ComponentID = x.Key, Quantity = x.Sum(y=>y.Quantity)}).ToListAsync();

            var projcomps = await (from component in _context.Components
                                   join projectComp in (
                                       _context.ProjectComponents
                                           .GroupBy(x => x.ComponentID)
                                           .Select(g => new
                                           {
                                               ComponentID = g.Key,
                                               Quantity = g.Sum(y => (int?)y.Quantity) ?? 0 // Ensure Sum returns a non-null value
                                           })
                                   )
                                   on component.ComponentID equals projectComp.ComponentID into cp
                                   from cps in cp.DefaultIfEmpty() // Handle left join
                                   select new
                                   {
                                       ComponentID = component.ComponentID,
                                       Quantity = cps != null ? cps.Quantity : 0 // Null check
                                   }).ToListAsync();





            //var projcomps = await (from component in _context.Components
            //                       join projectComp in _context.ProjectComponents
            //                       on component.ComponentID equals projectComp


            //IEnumerable<OwnsComponent> unusedItems = await (from owned in _context.OwnsComponent
            //                                                join component in _context.Components
            //                                                on owned.ComponentID equals component.ComponentID
            //                                                join usedInProject in _context.ProjectComponents
            //                                                on owned.ComponentID equals usedInProject.ComponentID
            //                                                where owned.UserID == userID
            //                                                select new OwnsComponent()
            //                                                {
            //                                                    OwnsComponentID = owned.ComponentID,
            //                                                    UserID = owned.UserID,
            //                                                    ComponentID = owned.ComponentID,
            //                                                    Quantity = (owned.Quantity - usedInProject.Quantity)
            //                                                }).ToListAsync();
            return Ok(null);
        }

        /// <summary>
        /// Get amount of 'Component' with such ID for given 'User'
        /// GET: ElectroDepot/OwnsComponents/GetOwnComponentFromUser/{UserID}/Component/{ComponentID}
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ComponentID"></param>
        /// <returns></returns>
        [HttpGet("GetOwnComponentFromUser/{UserID}/Component/{ComponentID}")]
        public async Task<ActionResult<OwnsComponentDTO>> GetOwnComponentFromUser(int UserID, int ComponentID)
        {
            User? user= await _context.Users.FindAsync(UserID);

            if (user == null)
            {
                return NotFound();
            }

            Component? component = await _context.Components.FindAsync(ComponentID);

            if (component == null)
            {
                return NotFound();
            }

            IEnumerable<OwnsComponentDTO> foundComponents = await _context.OwnsComponent.Where(x=>x.UserID == UserID && x.ComponentID == ComponentID).Select(y=>y.ToOwnsComponentDTO()).ToListAsync();
            OwnsComponentDTO foundComponent = foundComponents.FirstOrDefault();
            if(foundComponent == null)
            {
                return NotFound();
            }

            return Ok(foundComponent);
        }

        /// <summary>
        /// GET: ElectroDepot/OwnsComponents/GetAllOwnComponentFromUser/{UserID}
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet("GetAllOwnComponentFromUser/{UserID}")]
        public async Task<ActionResult<IEnumerable<OwnsComponentDTO>>> GetAllOwnComponentFromUser(int UserID)
        {
            User? user = await _context.Users.FindAsync(UserID);

            if (user == null)
            {
                return NotFound();
            }

            IEnumerable<OwnsComponentDTO> foundComponents = await _context.OwnsComponent.Where(x => x.UserID == UserID).Select(y => y.ToOwnsComponentDTO()).ToListAsync();

            return Ok(foundComponents);
        }

        /// <summary>
        /// GET: ElectroDepot/OwnsComponents/GetAllFreeToUseFromUser/{UserID}
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet("GetAllFreeToUseFromUser/{UserID}")]
        public async Task<ActionResult<IEnumerable<OwnsComponentDTO>>> GetAllFreeToUseFromUser(int UserID)
        {
            User? user = await _context.Users.FindAsync(UserID);

            if (user == null)
            {
                return NotFound();
            }

            IEnumerable<OwnsComponent> unusedComponents = await _context.OwnsComponent
                .Where(oc => !_context.ProjectComponents.Any(pc => pc.ComponentID == oc.ComponentID) && oc.UserID == UserID)
                .ToListAsync();

            return Ok(unusedComponents);
        }

        /// <summary>
        /// GET: ElectroDepot/OwnsComponents/GetAllUsedFromUser/{UserID}
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpGet("GetAllUsedFromUser/{UserID}")]
        public async Task<ActionResult<IEnumerable<OwnsComponentDTO>>> GetAllUsedFromUser(int UserID)
        {
            User? user = await _context.Users.FindAsync(UserID);

            if (user == null)
            {
                return NotFound();
            }

            IEnumerable<OwnsComponent> unusedComponents = await _context.OwnsComponent
                .Where(oc => _context.ProjectComponents.Any(pc => pc.ComponentID == oc.ComponentID) && oc.UserID == UserID)
                .ToListAsync();

            return Ok(unusedComponents);
        }
        #endregion
        #region Update
        /// <summary>
        /// PUT: ElectroDepot/OwnsComponents/Update/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateOwnsComponentDTO"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateOwnsComponent(int id, UpdateOwnsComponentDTO updateOwnsComponentDTO)
        {
            OwnsComponent? existingOwnsComponent = await _context.OwnsComponent.FindAsync(id);
            if (existingOwnsComponent == null)
            {
                return BadRequest(new { title = "OwnsComponent not found", status = 400, message = "OwnsComponent with this ID doesn't exist." });
            }

            existingOwnsComponent.Quantity = updateOwnsComponentDTO.Quantity;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnsComponentExists(id))
                {
                    return NotFound(new { title = "Update failed", status = 404, message = "OwnsComponent no longer exists." });
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
        /// DELETE: ElectroDepot/OwnsComponents/Delete/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOwnsComponent(int id)
        {
            var ownsComponent = await _context.OwnsComponent.FindAsync(id);
            if (ownsComponent == null)
            {
                return NotFound();
            }

            _context.OwnsComponent.Remove(ownsComponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion


        private bool OwnsComponentExists(int id)
        {
            return _context.OwnsComponent.Any(e => e.OwnsComponentID == id);
        }
    }
}
