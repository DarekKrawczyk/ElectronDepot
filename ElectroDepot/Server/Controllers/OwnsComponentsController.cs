using ElectroDepotClassLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.ExtensionMethods;
using Server.Models;

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
        [HttpPost]
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

            return Ok(createdOwnsComponent.ToDTO());
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/OwnsComponents
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OwnsComponentDTO>>> GetAllOwnsComponent()
        {
            return await _context.OwnsComponent.Select(x=>x.ToDTO()).ToListAsync();
        }

        /// <summary>
        /// GET: ElectroDepot/OwnsComponents/GetByID/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<OwnsComponent>> GetOwnsComponentByID(int id)
        {
            var ownsComponent = await _context.OwnsComponent.FindAsync(id);

            if (ownsComponent == null)
            {
                return NotFound();
            }

            return ownsComponent;
        }

        #endregion
        #region Update
        /// <summary>
        /// PUT: ElectroDepot/OwnsComponents/Update/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownsComponent"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutOwnsComponent(int id, OwnsComponent ownsComponent)
        {
            if (id != ownsComponent.OwnsComponentID)
            {
                return BadRequest();
            }

            OwnsComponent? existingOwnsComponent = await _context.OwnsComponent.FindAsync(id);
            if (existingOwnsComponent == null)
            {
                return BadRequest(new { title = "OwnsComponent not found", status = 400, message = "OwnsComponent with this ID doesn't exist." });
            }

            existingOwnsComponent.Quantity = ownsComponent.Quantity;

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
        // DELETE: api/OwnsComponents/5
        [HttpDelete("{id}")]
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
