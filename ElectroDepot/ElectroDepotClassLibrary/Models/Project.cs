using Avalonia.Media.Imaging;
using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Utility;

namespace ElectroDepotClassLibrary.Models
{
    public class Project
    {
        public int ID { get; }
        public int UserID { get; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; }
        public Bitmap Image { get; set; }
        public Project(int id, int userID, string name, User user, string description, DateTime createdAt, Bitmap image)
        {
            ID = id;
            UserID = userID;
            Name = name;
            User = user;
            Description = description;
            CreatedAt = createdAt;
            Image = image;
        }

        public override string ToString()
        {
            return $"ID: '{ID}', UserID: '{UserID}', Name: '{Name}', Description: '{Description}', CreatedAt: '{CreatedAt}'";
        }
    }

    internal static class ProjectExtensionMethods
    {
        internal static ProjectDTO ToDTO(this Project project)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                imageAsBytes = ImageConverterUtility.BitmapToBytes(project.Image);
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Exception while paring Bitmap to Byte[] for '{project.Name}' project!");
            }
            return new ProjectDTO(
                ID: project.ID, 
                UserID: project.UserID, 
                Name: project.Name, 
                Description: project.Description, 
                CreatedAt: project.CreatedAt,
                Image: imageAsBytes);
        }

        internal static UpdateProjectDTO ToUpdateDTO(this Project project)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                imageAsBytes = ImageConverterUtility.BitmapToBytes(project.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Bitmap to Byte[] for '{project.Name}' project!");
            }
            return new UpdateProjectDTO(
                Name: project.Name, 
                Description: project.Description,
                Image: imageAsBytes);
        }

        internal static CreateProjectDTO ToCreateDTO(this Project project)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                imageAsBytes = ImageConverterUtility.BitmapToBytes(project.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Bitmap to Byte[] for '{project.Name}' project!");
            }
            return new CreateProjectDTO(
                UserID: project.UserID, 
                Name: project.Name, 
                Description: project.Description,
                Image: imageAsBytes);
        }

        internal static Project ToModel(this ProjectDTO projectDTO)
        {
            Bitmap bitmap = null;
            try
            {
                bitmap = ImageConverterUtility.BytesToBitmap(projectDTO.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Byte[] to Bitmap for '{projectDTO.Name}' project!");
            }
            return new Project(
                id: projectDTO.ID, 
                userID: projectDTO.UserID,
                user: null,
                name: projectDTO.Name, 
                image: bitmap,
                description: projectDTO.Description, 
                createdAt: projectDTO.CreatedAt);
        }
    }
}
