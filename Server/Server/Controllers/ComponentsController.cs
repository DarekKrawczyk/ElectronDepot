using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroDepotClassLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.ExtensionMethods;
using Server.Models;

namespace Server.Controllers
{
    [Route("ElectronDepot/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ComponentsController(DatabaseContext context)
        {
            _context = context;
        }
        #region Create
        /// <summary>
        /// POST: ElectronDepot/Components/Create
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<ComponentDTO>> CreateComponent(CreateComponentDTO component)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Component? existingComponent = await _context.Components.FirstOrDefaultAsync(u => u.Name == component.Name);

            if (existingComponent != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "Component with this name already exists." });
            }

            Component newComponent = component.ToCategory();

            _context.Components.Add(newComponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComponent), new { id = newComponent.ComponentID}, newComponent);
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectronDepot/Components/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ComponentDTO>>> GetComponents()
        {
            return Ok(await _context.Components.Select(x=>x.ToDTO()).ToListAsync());
        }

        /// <summary>
        /// GET: ElectronDepot/Components/GetByID/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

        /// <summary>
        /// GET: ElectronDepot/Components/GetByName?name=someName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByName")]
        public async Task<ActionResult<Component>> GetComponentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest(new { title = "Invalid request", message = "Name cannot be null or empty." });
            }

            Component? component = await _context.Components.FirstOrDefaultAsync(x=>x.Name == name);

            if (component == null)
            {
                return NotFound();
            }

            return Ok(component);
        }
        #endregion
        #region Update
        /// <summary>
        /// PUT: ElectronDepot/Components/Update/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutComponent(int id, Component component)
        {
            if (id != component.ComponentID)
            {
                return BadRequest();
            }

            Component? existingComponent = await _context.Components.FirstOrDefaultAsync(u => u.Name == component.Name);

            if (existingComponent != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "Component with this name already exists." });
            }

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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
        /// DELETE: ElectronDepot/Components/Delete/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool ComponentExists(int id)
        {
            return _context.Components.Any(e => e.ComponentID == id);
        }
    }
}
