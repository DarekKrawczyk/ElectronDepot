using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class SupplierDataProvider : BaseDataProvider
    {
        public SupplierDataProvider(string url) : base(url)
        {
        }
        #region API Calls
        /// <summary>
        /// Create new supplier in database.
        /// </summary>
        /// <param name="supplierDTO"></param>
        /// <returns></returns>
        public async Task<bool> CreateSupplier(CreateSupplierDTO supplierDTO)
        {
            var json = JsonSerializer.Serialize(supplierDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = SupplierEndpoints.Create();
            var response = HTTPClient.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Get all suppliers from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SupplierDTO>> GetAllSuppliers()
        {
            try
            {
                string url = SupplierEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<SupplierDTO> categories = JsonSerializer.Deserialize<IEnumerable<SupplierDTO>>(json, options);
                    return categories;
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
        /// Gets supplier with such ID from database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<SupplierDTO> GetSupplierByID(int ID)
        {
            try
            {
                string url = SupplierEndpoints.GetByID(ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    SupplierDTO? supplier = JsonSerializer.Deserialize<SupplierDTO>(json, options);

                    return supplier;
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
        /// Gets supplier with such ID from database.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SupplierDTO> GetSupplierByName(string name)
        {
            try
            {
                string url = SupplierEndpoints.GetByName(name);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    SupplierDTO? supplier = JsonSerializer.Deserialize<SupplierDTO>(json, options);

                    return supplier;
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
        /// Updates supplier in database.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCategory(SupplierDTO supplierDTO)
        {
            UpdateSupplierDTO updateDTO = supplierDTO.ToUpdateSupplierDTO();

            var json = JsonSerializer.Serialize(updateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = SupplierEndpoints.Update(supplierDTO.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// Deletes supplier from database.
        /// </summary>
        /// <param name="supplierDTO"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSupplier(SupplierDTO supplierDTO)
        {
            string url = SupplierEndpoints.Delete(supplierDTO.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
