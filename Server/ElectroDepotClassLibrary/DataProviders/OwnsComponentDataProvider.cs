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
        public async Task<bool> CreateOwnComponentRelation(CreateOwnsComponentDTO ownsComponentDTO)
        {
            var json = JsonSerializer.Serialize(ownsComponentDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = OwnsComponentEndpoints.Create();
            var response = HTTPClient.PostAsync(url, content).Result;

            return response.IsSuccessStatusCode;
        }
        //public async Task<ComponentDTO> GetComponentByName(string name)
        //{
        //    try
        //    {
        //        string url = ComponentEndpoints.GetByName(name);
        //        var response = await _httpClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            JsonSerializerOptions options = new JsonSerializerOptions();
        //            options.PropertyNameCaseInsensitive = true;

        //            var json = await response.Content.ReadAsStringAsync();
        //            ComponentDTO? component = JsonSerializer.Deserialize<ComponentDTO>(json, options);

        //            return component;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public async Task<ComponentDTO> GetComponentByID(int ID)
        //{
        //    try
        //    {
        //        string url = ComponentEndpoints.GetByID(ID);
        //        var response = await _httpClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            JsonSerializerOptions options = new JsonSerializerOptions();
        //            options.PropertyNameCaseInsensitive = true;

        //            var json = await response.Content.ReadAsStringAsync();
        //            ComponentDTO? component = JsonSerializer.Deserialize<ComponentDTO>(json, options);

        //            return component;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public async Task<IEnumerable<ComponentDTO>> GetAllComponents()
        //{
        //    try
        //    {
        //        string url = ComponentEndpoints.GetAll();
        //        var response = await _httpClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            JsonSerializerOptions options = new JsonSerializerOptions();
        //            options.PropertyNameCaseInsensitive = true;

        //            var json = await response.Content.ReadAsStringAsync();
        //            IEnumerable<ComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<ComponentDTO>>(json, options);
        //            return components;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public async Task<bool> UpdateComponent(ComponentDTO component)
        //{
        //    UpdateComponentDTO updateDTO = component.ToUpdateComponentDTO();

        //    var json = JsonSerializer.Serialize(updateDTO);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    string url = ComponentEndpoints.Update(component.ID);
        //    var response = await _httpClient.PutAsync(url, content);

        //    return response.IsSuccessStatusCode;
        //}
        //public async Task<bool> DeleteComponent(int ID)
        //{
        //    string url = ComponentEndpoints.Delete(ID);
        //    var response = await _httpClient.DeleteAsync(url);
        //    return response.IsSuccessStatusCode;
        //}
        //public async Task<bool> DeleteComponent(ComponentDTO component)
        //{
        //    string url = ComponentEndpoints.Delete(component.ID);
        //    var response = await _httpClient.DeleteAsync(url);
        //    return response.IsSuccessStatusCode;
        //}
        #endregion
    }
}
