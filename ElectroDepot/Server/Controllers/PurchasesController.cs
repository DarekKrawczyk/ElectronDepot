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
    public class PurchasesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PurchasesController(DatabaseContext context)
        {
            _context = context;
        }

        #region Create
        /// <summary>
        /// POST: ElectroDepot/Purchases/Create
        /// </summary>
        /// <param name="createPurchaseDTO"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<Purchase>> CreatePurchase(CreatePurchaseDTO createPurchaseDTO)
        {
            User? userExists = await _context.Users.FindAsync(createPurchaseDTO.UserID);
            if (userExists == null)
            {
                return NotFound(new { title = "User not found", status = 404, message = $"User with given id: '{createPurchaseDTO.UserID}' doesn't exist" });
            }

            Supplier? supplierExists = await _context.Suppliers.FindAsync(createPurchaseDTO.SupplierID);
            if (supplierExists == null)
            {
                return NotFound(new { title = "Supplier not found", status = 404, message = $"Supplier with given id: '{createPurchaseDTO.SupplierID}' doesn't exist" });
            }

            Purchase purchase = createPurchaseDTO.ToPurchase();

            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase.ToPurchaseDTO());
        }
        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllPurchases()
        {
            return Ok(await _context.Purchases.Select(x => x.ToPurchaseDTO()).ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchaseByID(int id)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound(new { title = "Not found", code = "404" });
            }

            return Ok(purchase);
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAll/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPurchaseItem/{id}")]
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

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAllByUserID/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllByUserID/{id}")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllByUserID(int id)
        {
            User? foundUser = await _context.Users.FindAsync(id);

            if (foundUser == null)
            {
                return NotFound(new { title = "Not Found", code = "404", message = $"User with ID:{id} doesn't exsit" });
            }

            IEnumerable<PurchaseDTO> purchasesOfUser = await _context.Purchases.Where(x => x.UserID == id).Select(x => x.ToPurchaseDTO()).ToListAsync();

            return Ok(purchasesOfUser);
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAllBySupplierID/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllBySupplierID/{id}")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllBySupplierID(int id)
        {
            Supplier? foundSupplier = await _context.Suppliers.FindAsync(id);

            if (foundSupplier == null)
            {
                return NotFound(new { title = "Not Found", code = "404", message = $"Supplier with ID:{id} doesn't exsit" });
            }

            IEnumerable<PurchaseDTO> purchasesOfUser = await _context.Purchases.Where(x => x.SupplierID == id).Select(x => x.ToPurchaseDTO()).ToListAsync();

            return Ok(purchasesOfUser);
        }
        #endregion
        #region Update
        /// <summary>
        /// POST: ElectroDepot/Purchases/Update/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePurchaseDTO"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, UpdatePurchaseDTO updatePurchaseDTO)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(id);

            if(purchase == null)
            {
                NotFound();
            }

            purchase.TotalPrice = updatePurchaseDTO.TotalPrice;
            purchase.PurchasedDate = updatePurchaseDTO.PurchaseDate;

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

            return Ok();
        }
        #endregion
        #region Delete
        /// <summary>
        /// DELETE: ElectroDepot/Purchases/Delete/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound(new { title = "Not Found", code = "404" });
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseID == id);
        }
    }
}
