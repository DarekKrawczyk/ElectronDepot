using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class ProjectExtensions
    {
        public static ProjectDTO ToProjectDTO(this Project project)
        {
            return new ProjectDTO(ID: project.ProjectID, UserID: project.UserID, Name: project.Name, Description: project.Description, CreatedAt: project.CreatedAt);
        }

        public static Project ToProject(this CreateProjectDTO createProjectDTO)
        {
            return new Project()
            {
                UserID = createProjectDTO.UserID,
                Name = createProjectDTO.Name,
                Description = createProjectDTO.Description
            };
        }
    }
}
