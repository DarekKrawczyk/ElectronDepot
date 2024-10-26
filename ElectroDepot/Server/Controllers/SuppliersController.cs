using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroDepotClassLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Kerberos;
using Server.Context;
using Server.ExtensionMethods;
using Server.Models;

namespace Server.Controllers
{
    [Route("ElectroDepot/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SuppliersController(DatabaseContext context)
        {
            _context = context;
        }

        #region Create
        /// <summary>
        /// POST: ElectroDepot/Suppliers/Create
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<SupplierDTO>> CreateSupplier(CreateSupplierDTO supplierDTO)
        {
            Supplier? existingSupplier = await _context.Suppliers.FirstOrDefaultAsync(u => u.Name == supplierDTO.Name);

            if (existingSupplier != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "Supplier with this name already exists" });
            }

            Supplier newSupplier = supplierDTO.ToSupplier();

            _context.Suppliers.Add(newSupplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplierByID), new { id = newSupplier.SupplierID }, supplierDTO);
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/Suppliers/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetAllSuppliers()
        {
            return Ok(await _context.Suppliers.Select(x=>x.ToSupplierDTO()).ToListAsync());
        }

        /// <summary>
        /// GET: ElectroDepot/Suppliers/GetByID/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplierByID(int id)
        {
            Supplier? supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier.ToSupplierDTO());
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<SupplierDTO>> GetByName(string name)
        {
            Supplier? category = await _context.Suppliers.FirstOrDefaultAsync(u => u.Name == name);

            if (category == null)
            {
                return NotFound(new
                    {
                        title = "Not Found",
                        code = "404",
                        message = $"User with Name: {name} doesn't exist"
                    }
                );
            }

            return Ok(category.ToSupplierDTO());
        }
        #endregion
        #region Update
        /// <summary>
        /// PUT: ElectroDepot/Suppliers/Update/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return BadRequest();
            }

            var existingSupplier = await _context.Suppliers.FirstOrDefaultAsync(u => u.Name == supplier.Name);

            if (existingSupplier != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "Supplier with this name already exists" });
            }

            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.Suppliers.FindAsync(id));
        }
        #endregion
        #region Delete
        /// <summary>
        /// DELETE: ElectroDepot/Suppliers/Delete/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierID == id);
        }
    }
}
