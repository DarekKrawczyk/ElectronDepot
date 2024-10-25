using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
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
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSupplier = await _context.Suppliers
                .FirstOrDefaultAsync(u => u.Name == supplier.Name);

            if (existingSupplier != null)
            {
                return Conflict(new { title = "Conflict", status = 409, message = "Supplier with this name already exists" });
            }

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierID }, supplier);
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/Suppliers/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        /// <summary>
        /// GET: ElectroDepot/Suppliers/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
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
