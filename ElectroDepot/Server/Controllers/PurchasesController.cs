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
        public async Task<ActionResult<PurchaseDTO>> CreatePurchase(CreatePurchaseDTO createPurchaseDTO)
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
        [HttpGet("GetByID/{ID}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchaseByID(int ID)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(ID);

            if (purchase == null)
            {
                return NotFound(new { title = "Not found", code = "404" });
            }

            return Ok(purchase.ToPurchaseDTO());
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAll/{ID}
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetPurchaseItemByID/{ID}")]
        public async Task<ActionResult<IEnumerable<PurchaseItemDTO>>> GetPurchaseItem(int ID)
        {
            Purchase? foundPurchase = await _context.Purchases.FindAsync(ID);

            if (foundPurchase == null)
            {
                return NotFound();
            }

            List<PurchaseItemDTO> foundPurchaseItems = await _context.PurchaseItems.Where(x => x.PurchaseID == ID).Select(x=>x.ToPurchaseItemDTO()).ToListAsync();

            return foundPurchaseItems;
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAllByUserID/{ID}
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetAllByUserID/{ID}")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllByUserID(int ID)
        {
            User? foundUser = await _context.Users.FindAsync(ID);

            if (foundUser == null)
            {
                return NotFound();
            }

            IEnumerable<PurchaseDTO> purchasesOfUser = await _context.Purchases.Where(x => x.UserID == ID).Select(x => x.ToPurchaseDTO()).ToListAsync();

            return Ok(purchasesOfUser);
        }

        /// <summary>
        /// GET: ElectroDepot/Purchases/GetAllBySupplierID/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllBySupplierID/{ID}")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllBySupplierID(int ID)
        {
            Supplier? foundSupplier = await _context.Suppliers.FindAsync(ID);

            if (foundSupplier == null)
            {
                return NotFound(new { title = "Not Found", code = "404", message = $"Supplier with ID:{ID} doesn't exsit" });
            }

            IEnumerable<PurchaseDTO> purchasesOfUser = await _context.Purchases.Where(x => x.SupplierID == ID).Select(x => x.ToPurchaseDTO()).ToListAsync();

            return Ok(purchasesOfUser);
        }
        #endregion
        #region Update
        /// <summary>
        /// POST: ElectroDepot/Purchases/Update/{ID}
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="updatePurchaseDTO"></param>
        /// <returns></returns>
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> UpdatePurchase(int ID, UpdatePurchaseDTO updatePurchaseDTO)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(ID);

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
                if (!PurchaseExists(ID))
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
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> DeletePurchase(int ID)
        {
            Purchase? purchase = await _context.Purchases.FindAsync(ID);
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
