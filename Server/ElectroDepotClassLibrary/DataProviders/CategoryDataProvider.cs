using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class CategoryDataProvider
    {
        #region Fields
        private string _url = string.Empty;
        private HttpClient _httpClient;
        #endregion
        #region Ctor
        public CategoryDataProvider(string url)
        {
            _url = url;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_url);
        }
        #endregion
        #region API Calls
        public async Task<bool> CreateCategory(CreateCategoryDTO category)
        {
            var json = JsonSerializer.Serialize(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = CategoryEndpoints.Create();
            var response = _httpClient.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            try
            {
                string url = CategoryEndpoints.GetAll();
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<CategoryDTO> categories = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(json, options);

                    List<CategoryDTO> result = categories.ToList();
                    return result;
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
        public async Task<bool> UpdateCategory(CategoryDTO category)
        {
            UpdateCategoryDTO updateDTO = new UpdateCategoryDTO(Name: category.Name, Description: category.Description);

            var json = JsonSerializer.Serialize(updateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = CategoryEndpoints.Update(category.ID);
            var response = await _httpClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteCategory(CategoryDTO category)
        {
            string url = CategoryEndpoints.Delete(category.ID);
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}