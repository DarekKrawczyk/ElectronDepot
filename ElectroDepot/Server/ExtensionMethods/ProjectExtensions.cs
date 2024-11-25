using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Services;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class ProjectExtensions
    {
        public static ProjectDTO ToProjectDTO(this Project project, ImageStorageService imageStorageService)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                // Disable this to improve speed
                Console.WriteLine($"Sending binary data of project's image is disabled!");
                //imageAsBytes = imageStorageService.RetrieveProjectImage(project.ImageURI);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exeption while retrieving image from Server for '{project.Name}' project. Empty byte[] inserted!");
            }
            return new ProjectDTO(
                ID: project.ProjectID, 
                UserID: project.UserID, 
                Name: project.Name, 
                Description: project.Description, 
                CreatedAt: project.CreatedAt,
                Image: imageAsBytes);
        }

        public static Project ToProject(this CreateProjectDTO createProjectDTO, ImageStorageService imageStorageService)
        {
            // Handle image
            string imageIdentifier = string.Empty;
            try
            {
                imageIdentifier = imageStorageService.InsertProjectImage(createProjectDTO.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while inserting image for '{createProjectDTO.Name}' project! Empty string inserted");
            }
            return new Project()
            {
                UserID = createProjectDTO.UserID,
                Name = createProjectDTO.Name,
                Description = createProjectDTO.Description,
                ImageURI = imageIdentifier,
            };
        }
    }
}
