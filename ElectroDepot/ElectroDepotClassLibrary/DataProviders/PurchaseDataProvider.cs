using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class PurchaseDataProvider : BaseDataProvider
    {
        public PurchaseDataProvider(string url) : base(url)
        {
        }
        #region API Calls
        /// <summary>
        /// Creates new 'Purchase' in database.
        /// </summary>
        /// <param name="createPurchaseDTO"></param>
        /// <returns></returns>
        public async Task<bool> CreatePurchase(CreatePurchaseDTO createPurchaseDTO)
        {
            var json = JsonSerializer.Serialize(createPurchaseDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = PurchaseEndpoints.Create();
            var response = HTTPClient.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }

        public async Task<PurchaseDTO> GetPurchaseByID(int ID)
        {
            try
            {
                string url = PurchaseEndpoints.GetByID(ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    PurchaseDTO? purchase = JsonSerializer.Deserialize<PurchaseDTO>(json, options);
                    return purchase;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all 'Purchase's from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaseDTO>> GetAllPurchases()
        {
            try
            {
                string url = PurchaseEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<PurchaseDTO> purchases = JsonSerializer.Deserialize<IEnumerable<PurchaseDTO>>(json, options);
                    return purchases;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Gets all 'Purchases' of given 'User'
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaseDTO>> GetAllPurchasesFromUser(UserDTO userDTO)
        {
            try
            {
                string url = PurchaseEndpoints.GetAllByUserID(userDTO.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<PurchaseDTO> purchases = JsonSerializer.Deserialize<IEnumerable<PurchaseDTO>>(json, options);
                    return purchases;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Gets all 'Purchases' of given 'Supplier'
        /// </summary>
        /// <param name="supplierDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaseDTO>> GetAllPurchasesFromSupplier(Supplier supplierDTO)
        {
            try
            {
                string url = PurchaseEndpoints.GetAllBySupplierID(supplierDTO.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<PurchaseDTO> purchases = JsonSerializer.Deserialize<IEnumerable<PurchaseDTO>>(json, options);
                    return purchases;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Updated 'Purchase' in database
        /// </summary>
        /// <param name="purchaseDTO"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePurchase(PurchaseDTO purchaseDTO)
        {
            try
            {
                UpdatePurchaseDTO updateDTO = purchaseDTO.ToUpdatePurchaseDTO();

                var json = JsonSerializer.Serialize(updateDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = PurchaseEndpoints.Update(purchaseDTO.ID);
                var response = await HTTPClient.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch(Exception exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Deletes 'Purchase' from database.
        /// </summary>
        /// <param name="purchaseDTO"></param>
        /// <returns></returns>
        public async Task<bool> DeletePuchase(PurchaseDTO purchaseDTO)
        {
            string url = PurchaseEndpoints.Delete(purchaseDTO.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
