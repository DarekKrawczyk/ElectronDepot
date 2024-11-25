using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;
using ElectroDepotClassLibrary.Models;
using ElectroDepotClassLibrary.Utility;
using Avalonia.Media.Imaging;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class UserDataProvider : BaseDataProvider
    {
        public UserDataProvider(string url) : base(url) { }
        #region API Calls
        public async Task<bool> CreateUser(User user)
        {
            var json = JsonSerializer.Serialize(user.ToCreateDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = UserEndpoints.Create();
            var response = await HTTPClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<User> GetUserByUsername(string name)
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

                    return user?.ToModel();
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
            User? found = await GetUserByUsername(username);
            if (found == null)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUserByEMail(string EMail)
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

                    return user?.ToModel();
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

        public async Task<Bitmap> GetImageOfUserByID(User user)
        {
            byte[] image = new byte[] { };
            Bitmap bitmap = null;
            try
            {
                string url = UserEndpoints.GetImageOfUserByID(user.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    image = JsonSerializer.Deserialize<byte[]>(json, options);

                    bitmap = ImageConverterUtility.BytesToBitmap(image);

                    return bitmap;
                }
                else
                {
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                return bitmap;
            }
        }

        public async Task<bool> UserWithEMailExists(string EMail)
        {
            User? found = await GetUserByEMail(EMail);
            if (found == null)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUserByID(int ID)
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

                    return user.ToModel();
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

        public async Task<bool> UpdateUser(int UserID, User user)
        {
            var json = JsonSerializer.Serialize(user.ToUpdateDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = UserEndpoints.Update(UserID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
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
                    List<User> usersAsModel = users.Select(x=>x.ToModel()).ToList();

                    return usersAsModel;
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

        public async Task<bool> DeleteUser(User user)
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
