using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class ProjectDataProvider : BaseDataProvider
    {
        public ProjectDataProvider(string url) : base(url)
        {
        }
        #region API Calls
        public async Task<bool> CreateUser(CreateProjectDTO project)
        {
            var json = JsonSerializer.Serialize(project);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ProjectEndpoints.Create();
            var response = await HTTPClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            try
            {
                string url = ProjectEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ProjectDTO> projects = JsonSerializer.Deserialize<IEnumerable<ProjectDTO>>(json, options);

                    return projects;
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
        public async Task<IEnumerable<ProjectDTO>> GetAllProjectOfUser(UserDTO user)
        {
            try
            {
                string url = ProjectEndpoints.GetAllOfUser(user.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ProjectDTO> projectsOfUser = JsonSerializer.Deserialize<IEnumerable<ProjectDTO>>(json, options);

                    return projectsOfUser;
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
        //public async Task<bool> UserWithUsernameExists(string username)
        //{
        //    UserDTO? found = await GetUserByUsername(username);
        //    if (found == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public async Task<UserDTO> GetUserByEMail(string EMail)
        //{
        //    try
        //    {
        //        string url = UserEndpoints.GetByEMail(EMail);
        //        var response = await HTTPClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            JsonSerializerOptions options = new JsonSerializerOptions();
        //            options.PropertyNameCaseInsensitive = true;

        //            var json = await response.Content.ReadAsStringAsync();
        //            UserDTO? user = JsonSerializer.Deserialize<UserDTO>(json, options);

        //            return user;
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
        //public async Task<bool> UserWithEMailExists(string EMail)
        //{
        //    UserDTO? found = await GetUserByEMail(EMail);
        //    if (found == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public async Task<UserDTO> GetUserByID(int ID)
        //{
        //    try
        //    {
        //        string url = UserEndpoints.GetByID(ID);
        //        var response = await HTTPClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            JsonSerializerOptions options = new JsonSerializerOptions();
        //            options.PropertyNameCaseInsensitive = true;

        //            var json = await response.Content.ReadAsStringAsync();
        //            UserDTO? user = JsonSerializer.Deserialize<UserDTO>(json, options);

        //            return user;
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
        //public async Task<bool> UpdateUser(UserDTO user)
        //{
        //    var json = JsonSerializer.Serialize(user);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    string url = UserEndpoints.Update(user.ID);
        //    var response = await HTTPClient.PutAsync(url, content);

        //    throw new Exception("TODO: Problem with updating used because can cast from UserDTO to UpdateUserDTO, maybo just create method to change" +
        //        "password and email?");
        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<bool> DeleteUser(UserDTO user)
        //{
        //    string url = UserEndpoints.Delete(user.ID);
        //    var response = await HTTPClient.DeleteAsync(url);
        //    return response.IsSuccessStatusCode;
        //}
        //public async Task<bool> DeleteUser(int ID)
        //{
        //    string url = UserEndpoints.Delete(ID);
        //    var response = await HTTPClient.DeleteAsync(url);
        //    return response.IsSuccessStatusCode;
        //}
        #endregion
    }
}
