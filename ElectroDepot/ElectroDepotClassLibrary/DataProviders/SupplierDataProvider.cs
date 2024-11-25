using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;
using ElectroDepotClassLibrary.Models;

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
        /// <param name="supplier"></param>
        /// <returns></returns>
        public async Task<bool> CreateSupplier(Supplier supplier)
        {
            var json = JsonSerializer.Serialize(supplier.ToCreateDTO());
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
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
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
                    return categories.Select(x=>x.ToModel()).ToList();
                }
                else
                {
                    return new List<Supplier>();
                }
            }
            catch (Exception ex)
            {
                return new List<Supplier>();
            }
        }
        /// <summary>
        /// Gets supplier with such ID from database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Supplier> GetSupplierByID(int ID)
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

                    return supplier.ToModel();
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
        public async Task<Supplier> GetSupplierByName(string name)
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

                    return supplier.ToModel();
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
        /// <param name="supplier"></param>
        /// <returns></returns>
        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            UpdateSupplierDTO updateDTO = supplier.ToUpdateDTO();

            var json = JsonSerializer.Serialize(updateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = SupplierEndpoints.Update(supplier.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// Deletes supplier from database.
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSupplier(Supplier supplier)
        {
            string url = SupplierEndpoints.Delete(supplier.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
