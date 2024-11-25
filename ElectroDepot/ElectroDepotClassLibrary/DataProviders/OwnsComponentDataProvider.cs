using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class OwnsComponentDataProvider : BaseDataProvider
    {
        public OwnsComponentDataProvider(string url) : base(url) { }
        #region API Calls
        public async Task<bool> CreateOwnComponent(CreateOwnsComponentDTO ownsComponentDTO)
        {
            var json = JsonSerializer.Serialize(ownsComponentDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = OwnsComponentEndpoints.Create();
            var response = HTTPClient.PostAsync(url, content).Result;

            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<OwnsComponentDTO>> GetAllOwnsComponents()
        {
            try
            {
                string url = OwnsComponentEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<OwnsComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<OwnsComponentDTO>>(json, options);
                    return components;
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

        public async Task<IEnumerable<OwnsComponentDTO>> GetAllUsedComponentsFromUser(User user)
        {
            try
            {
                string url = OwnsComponentEndpoints.GetAllUsedFromUser(user.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<OwnsComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<OwnsComponentDTO>>(json, options);
                    return components;
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

        public async Task<IEnumerable<OwnsComponentDTO>> GetAllFreeToUseComponentsFromUser(User user)
        {
            try
            {
                string url = OwnsComponentEndpoints.GetAllFreeToUseFromUser(user.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<OwnsComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<OwnsComponentDTO>>(json, options);
                    return components;
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

        public async Task<IEnumerable<OwnsComponentDTO>> GetAllOwnsComponentsFromUser(User user)
        {
            try
            {
                string url = OwnsComponentEndpoints.GetAllOwnComponentFromUser(user.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<OwnsComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<OwnsComponentDTO>>(json, options);
                    return components;
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

        public async Task<OwnsComponentDTO> GetOwnComponentsFromUser(User user, Component component)
        {
            try
            {
                string url = OwnsComponentEndpoints.GetOwnComponentFromUser(user.ID, component.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    OwnsComponentDTO ownsComponent = JsonSerializer.Deserialize<OwnsComponentDTO>(json, options);
                    return ownsComponent;
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

        public async Task<bool> UpdateOwnsComponent(OwnsComponentDTO ownsComponentDTO)
        {
            UpdateOwnsComponentDTO updateDTO = ownsComponentDTO.ToUpdateOwnsComponentsDTO();

            var json = JsonSerializer.Serialize(updateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ComponentEndpoints.Update(ownsComponentDTO.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteComponent(OwnsComponentDTO ownsComponentDTO)
        {
            string url = ComponentEndpoints.Delete(ownsComponentDTO.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}