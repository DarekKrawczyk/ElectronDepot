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
        public async Task<bool> CreateProject(CreateProjectDTO project)
        {
            var json = JsonSerializer.Serialize(project);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ProjectEndpoints.Create();
            var response = await HTTPClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<ProjectDTO> GetProjectByID(int ProjectID)
        {
            try
            {
                string url = ProjectEndpoints.GetByID(ProjectID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    ProjectDTO projectWithID= JsonSerializer.Deserialize<ProjectDTO>(json, options);

                    return projectWithID;
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

        public async Task<double> GetProjectPrice(ProjectDTO project)
        {
            try
            {
                string url = ProjectEndpoints.GetPriceByID(project.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    double price = JsonSerializer.Deserialize<double>(json, options);
                    return price;
                }
                else
                {
                    return -1.0;
                }
            }
            catch (Exception ex)
            {
                return -1.0;
            }
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
        public async Task<IEnumerable<ComponentDTO>> GetAllComponentsFromProject(ProjectDTO projectDTO)
        {
            try
            {
                string url = ProjectEndpoints.GetAllComponentsFromProject(projectDTO.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ComponentDTO> componentsOfProject = JsonSerializer.Deserialize<IEnumerable<ComponentDTO>>(json, options);

                    return componentsOfProject;
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
        public async Task<bool> UpdateProject(ProjectDTO project)
        {
            var json = JsonSerializer.Serialize(project.ToUpdateProjectDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ProjectEndpoints.Update(project.ID);
            var response = await HTTPClient.PutAsync(url, content);
            
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteProject(ProjectDTO projectDTO)
        {
            string url = ProjectEndpoints.Delete(projectDTO.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}