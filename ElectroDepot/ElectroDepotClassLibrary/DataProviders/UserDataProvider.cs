using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;
using ElectroDepotClassLibrary.DataProviders.Interfaces;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class UserDataProvider : BaseDataProvider, IUserDataProvider
    {
        public UserDataProvider(string url) : base(url) { }
        #region API Calls
        public async Task<bool> CreateUser(CreateUserDTO user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = UserEndpoints.Create();
            var response = await HTTPClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<UserDTO> GetUserByUsername(string name)
        {
            try
            {
                string url = UserEndpoints.GetByUsername(name);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    UserDTO? user = JsonSerializer.Deserialize<UserDTO>(json, options);

                    return user;
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
        public async Task<bool> UserWithUsernameExists(string username)
        {
            UserDTO? found = await GetUserByUsername(username);
            if (found == null)
            {
                return false;
            }
            return true;
        }
        public async Task<UserDTO> GetUserByEMail(string EMail)
        {
            try
            {
                string url = UserEndpoints.GetByEMail(EMail);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    UserDTO? user = JsonSerializer.Deserialize<UserDTO>(json, options);

                    return user;
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
        public async Task<bool> UserWithEMailExists(string EMail)
        {
            UserDTO? found = await GetUserByEMail(EMail);
            if (found == null)
            {
                return false;
            }
            return true;
        }
        public async Task<UserDTO> GetUserByID(int ID)
        {
            try
            {
                string url = UserEndpoints.GetByID(ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    UserDTO? user = JsonSerializer.Deserialize<UserDTO>(json, options);

                    return user;
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
        public async Task<bool> UpdateUser(UserDTO user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = UserEndpoints.Update(user.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                string url = UserEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<UserDTO> users = JsonSerializer.Deserialize<IEnumerable<UserDTO>>(json, options);

                    return users;
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
        public async Task<bool> DeleteUser(UserDTO user)
        {
            string url = UserEndpoints.Delete(user.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteUser(int ID)
        {
            string url = UserEndpoints.Delete(ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
