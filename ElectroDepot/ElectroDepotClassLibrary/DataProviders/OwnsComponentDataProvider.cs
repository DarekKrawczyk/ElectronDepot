using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class OwnsComponentDataProvider : BaseDataProvider
    {
        public OwnsComponentDataProvider(string url) : base(url)
        {
        }
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

        public async Task<IEnumerable<OwnsComponentDTO>> GetAllFreeToUseComponentsFromUser(UserDTO user)
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

        public async Task<IEnumerable<OwnsComponentDTO>> GetAllOwnsComponentsFromUser(UserDTO userDTO)
        {
            try
            {
                string url = OwnsComponentEndpoints.GetAllOwnComponentFromUser(userDTO.ID);
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

        public async Task<OwnsComponentDTO> GetOwnComponentsFromUser(UserDTO userDTO, ComponentDTO compDTO)
        {
            try
            {
                string url = OwnsComponentEndpoints.GetOwnComponentFromUser(userDTO.ID, compDTO.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    OwnsComponentDTO component = JsonSerializer.Deserialize<OwnsComponentDTO>(json, options);
                    return component;
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
