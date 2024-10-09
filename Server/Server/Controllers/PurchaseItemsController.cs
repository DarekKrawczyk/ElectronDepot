using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Models;

namespace Server.Controllers
{
    [Route("ElectroDepot/[controller]")]
    [ApiController]
    public class PurchaseItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PurchaseItemsController(DatabaseContext context)
        {
            _context = context;
        }
        #region Create
        /// <summary>
        /// POST: ElectroDepot/PurchaseItems/Create
        /// </summary>
        /// <param name="purchaseItem"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<PurchaseItem>> PostPurchaseItem(PurchaseItem purchaseItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Purchase? purchase = await _context.Purchases.FindAsync(purchaseItem.PurchaseID);

            if (purchase == null)
            {
                return NotFound(new { title = "Not Found", status = 404, message = $"Purchase with ID:{purchaseItem.PurchaseID} doesn't exist" });
            }

            // Component
            //Purchase? purchase = await _context.Purchases.FindAsync(purchaseItem.PurchaseID);

            //if (existingUserByEmail != null)
            //{
            //    return Conflict(new { title = "Conflict", status = 409, message = "A user with this email already exists." });
            //}

            _context.PurchaseItems.Add(purchaseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseItem), new { id = purchaseItem.PurchaseItemID }, purchaseItem);
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/PurchaseItems/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PurchaseItem>>> GetPurchaseItems()
        {
            return Ok(await _context.PurchaseItems.ToListAsync());
        }

        /// <summary>
        /// GET: ElectroDepot/PurchaseItems/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PurchaseItem>>> GetPurchaseItem(int id)
        {
            PurchaseItem? foundPurchase = await _context.PurchaseItems.FindAsync(id);

            if (foundPurchase == null)
            {
                return NotFound(new { title = "Not Found", code = "404", message = $"PurchaseItem with ID:{id} doesn't exsit" });
            }

            return Ok(foundPurchase);
        }
        #endregion
        #region Delete
        /// <summary>
        /// DELETE: ElectronDepot/PurchaseItems/Delete/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePurchaseItem(int id)
        {
            PurchaseItem? purchaseItem = await _context.PurchaseItems.FindAsync(id);
            if (purchaseItem == null)
            {
                return NotFound(new { title = "Not Found", code = "404", message = $"PurchasItem with ID:{id} doesn't exist" });
            }

            _context.PurchaseItems.Remove(purchaseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool PurchaseItemExists(int id)
        {
            return _context.PurchaseItems.Any(e => e.PurchaseItemID == id);
        }
    }
}
