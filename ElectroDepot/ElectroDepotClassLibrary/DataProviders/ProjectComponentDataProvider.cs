using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using System.Text.Json;
using System.Text;

namespace ElectroDepotClassLibrary.DataProviders
{
    public class ProjectComponentDataProvider : BaseDataProvider
    {
        public ProjectComponentDataProvider(string url) : base(url)
        {
        }
        #region API Calls
        public async Task<bool> CreateProjectComponent(CreateProjectComponentDTO projectComponentDTO)
        {
            var json = JsonSerializer.Serialize(projectComponentDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ProjectComponentEndpoints.Create();
            var response = await HTTPClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<ProjectComponentDTO>> GetAllProjectComponents()
        {
            try
            {
                string url = ProjectComponentEndpoints.GetAll();
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ProjectComponentDTO> projects = JsonSerializer.Deserialize<IEnumerable<ProjectComponentDTO>>(json, options);

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
        public async Task<IEnumerable<ProjectComponentDTO>> GetAllProjectComponentsOfProject(ProjectDTO projectDTO)
        {
            try
            {
                string url = ProjectComponentEndpoints.GetAllByProject(projectDTO.ID);
                var response = await HTTPClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;

                    var json = await response.Content.ReadAsStringAsync();
                    IEnumerable<ProjectComponentDTO> projectsOfUser = JsonSerializer.Deserialize<IEnumerable<ProjectComponentDTO>>(json, options);

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
        public async Task<bool> UpdateProjectComponent(ProjectComponentDTO projectComponentDTO)
        {
            var json = JsonSerializer.Serialize(projectComponentDTO.ToUpdateProjectComponentDTO());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = ProjectComponentEndpoints.Update(projectComponentDTO.ID);
            var response = await HTTPClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteProjectComponent(ProjectComponentDTO projectComponentDTO)
        {
            string url = ProjectComponentEndpoints.Delete(projectComponentDTO.ID);
            var response = await HTTPClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
