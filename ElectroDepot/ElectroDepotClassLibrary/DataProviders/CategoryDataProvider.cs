using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using ElectroDepotClassLibrary.Models;
using System.Text;
using System.Text.Json;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class CategoryDataProvider : BaseDataProvider
    {
        public CategoryDataProvider(string url) : base(url) { }

        #region API Calls
        public async Task<bool> CreateCategory(Category category)
        {
            var json = JsonSerializer.Serialize(category.ToCreateDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = CategoryEndpoints.Create();
            var response = HTTPClient.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            try
            {
                string url = CategoryEndpoints.GetByName(name);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    CategoryDTO? category = JsonSerializer.Deserialize<CategoryDTO>(json, options);

                    return category.ToModel();
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

        public async Task<Category> GetCategoryByID(int ID)
        {
            try
            {
                string url = CategoryEndpoints.GetByID(ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    CategoryDTO? category = JsonSerializer.Deserialize<CategoryDTO>(json, options);

                    return category.ToModel();
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

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                string url = CategoryEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<CategoryDTO> categories = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(json, options);

                    List<Category> result = categories.Select(x => x.ToModel()).ToList();
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

        public async Task<bool> UpdateCategory(Category category)
        {
            UpdateCategoryDTO updateDTO = category.ToUpdateDTO();

            var json = JsonSerializer.Serialize(updateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = CategoryEndpoints.Update(category.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            string url = CategoryEndpoints.Delete(category.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(int ID)
        {
            string url = CategoryEndpoints.Delete(ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}