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
    public class PurchasesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PurchasesController(DatabaseContext context)
        {
            _context = context;
        }

        #region Create
        /// <summary>
        /// POST: ElectroDepot/Purchases
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userExists = await _context.Users.FindAsync(purchase.UserID);
            if (userExists == null)
            {
                return NotFound(new { title = "User not found", status = 404, message = $"User with given id: '{purchase.UserID}' doesn't exist" });
            }

            var supplierExists = await _context.Suppliers.FindAsync(purchase.SupplierID);
            if (supplierExists == null)
            {
                return NotFound(new { title = "Supplier not found", status = 404, message = $"Supplier with given id: '{purchase.SupplierID}' doesn't exist" });
            }

            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchase), new { id = purchase.PurchaseID }, purchase);
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            return Ok(await _context.Purchases.ToListAsync());
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound(new { title ="Not found", code = "404" });
            }

            /*
            User? user = await _context.Users.FindAsync(purchase.UserID);
            Supplier? supplier = await _context.Suppliers.FindAsync(purchase.SupplierID);

            purchase.User = user;
            purchase.Supplier = supplier;
            */

            return Ok(purchase);
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAll/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAll/{id}")]
        public async Task<ActionResult<IEnumerable<PurchaseItem>>> GetPurchaseItem(int id)
        {
            Purchase? foundPurchase = await _context.Purchases.FindAsync(id);

            if (foundPurchase == null)
            {
                return NotFound(new { title = "Not Found", code = "404", message = $"Purchase with ID:{id} doesn't exsit" });
            }

            List<PurchaseItem> foundPurchaseItems = await _context.PurchaseItems.Where(x => x.PurchaseID == id).ToListAsync();

            return foundPurchaseItems;
        }
        #endregion
        #region Update
        // PUT: api/Purchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.PurchaseID)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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
        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound(new { title = "Not Found", code = "404" });
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseID == id);
        }
    }
}
