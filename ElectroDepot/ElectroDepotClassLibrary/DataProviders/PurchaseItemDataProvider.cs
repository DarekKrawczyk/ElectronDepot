using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class PurchaseItemDataProvider : BaseDataProvider
    {
        public PurchaseItemDataProvider(string url) : base(url)
        {
        }
        #region API Calls
        public async Task<bool> CreatePurchaseItem(CreatePurchaseItemDTO createPurchaseItemDTO)
        {
            var json = JsonSerializer.Serialize(createPurchaseItemDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = PurchaseItemEndpoints.Create();
            var response = await HTTPClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<PurchaseItemDTO>> GetAllPurchaseItems()
        {
            try
            {
                string url = PurchaseItemEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<PurchaseItemDTO> purchaseItems = JsonSerializer.Deserialize<IEnumerable<PurchaseItemDTO>>(json, options);

                    return purchaseItems;
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
        public async Task<PurchaseItemDTO> GetPurchaseItemByID(int ID)
        {
            try
            {
                string url = PurchaseItemEndpoints.GetByID(ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    PurchaseItemDTO purchaseItems = JsonSerializer.Deserialize<PurchaseItemDTO>(json, options);

                    return purchaseItems;
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
        public async Task<bool> UpdatePurchaseItem(PurchaseItemDTO purchaseItemDTO)
        {
            var json = JsonSerializer.Serialize(purchaseItemDTO.ToUpdatePurchaseItemDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = PurchaseItemEndpoints.Update(purchaseItemDTO.ID);
            var response = await HTTPClient.PutAsync(url, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePuchaseItem(PurchaseItemDTO purchaseItemDTO)
        {
            string url = PurchaseItemEndpoints.Delete(purchaseItemDTO.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
