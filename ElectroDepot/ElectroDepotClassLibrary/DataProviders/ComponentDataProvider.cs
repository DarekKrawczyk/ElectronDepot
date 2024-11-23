﻿using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using ElectroDepotClassLibrary.Models;
using System.Text;
using System.Text.Json;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class ComponentDataProvider : BaseDataProvider
    {
        public ComponentDataProvider(string url) : base(url) { }
        #region API Calls
        public async Task<bool> CreateComponent(Component component)
        {
            var json = JsonSerializer.Serialize(component.ToCreateDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ComponentEndpoints.Create();
            var response = HTTPClient.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }

        public async Task<Component> GetComponentByName(string name)
        {
            try
            {
                string url = ComponentEndpoints.GetByName(name);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    ComponentDTO? component = JsonSerializer.Deserialize<ComponentDTO>(json, options);

                    return component.ToModel();
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

        public async Task<Component> GetComponentByID(int ID)
        {
            try
            {
                string url = ComponentEndpoints.GetByID(ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    ComponentDTO? component = JsonSerializer.Deserialize<ComponentDTO>(json, options);

                    return component.ToModel();
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

        public async Task<IEnumerable<Component>> GetAllComponents()
        {
            try
            {
                string url = ComponentEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<ComponentDTO>>(json, options);
                    List<Component> componentsModels = components.Select(x=>x.ToModel()).ToList();
                    return componentsModels;
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

        public async Task<IEnumerable<Component>> GetAllAvailableComponentsFromUser(UserDTO user)
        {
            try
            {
                string url = ComponentEndpoints.GetAvailableComponentsFromUser(user.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<ComponentDTO>>(json, options);
                    List<Component> componentsModels = components.Select(x=>x.ToModel()).ToList();
                    return componentsModels;
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

        public async Task<IEnumerable<Component>> GetAllUserComponent(int UserID)
        {
            try
            {
                string url = ComponentEndpoints.GetUserComponents(UserID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ComponentDTO> components = JsonSerializer.Deserialize<IEnumerable<ComponentDTO>>(json, options);
                    List<Component> componentsModels = components.Select(x=>x.ToModel()).ToList();
                    return componentsModels;
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

        public async Task<bool> UpdateComponent(Component component)
        {
            UpdateComponentDTO updateDTO = component.ToUpdateDTO();

            var json = JsonSerializer.Serialize(updateDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ComponentEndpoints.Update(component.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteComponent(int ID)
        {
            string url = ComponentEndpoints.Delete(ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteComponent(Component component)
        {
            string url = ComponentEndpoints.Delete(component.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}