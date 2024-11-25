using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Services;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class UserExtensions
    {
        public static UserDTO ToDTO(this User user, ImageStorageService imageStorageService)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                // Disable this to improve speed
                Console.WriteLine($"Sending binary data of project's image is disabled!");
                //imageAsBytes = imageStorageService.RetrieveProjectImage(project.ImageURI);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption while retrieving image from Server for '{user.Username}' user. Empty byte[] inserted!");
            }
            return new UserDTO(
                user.UserID,
                user.Username,
                user.Email,
                imageAsBytes
            );
        }

        public static User ToUser(this UserDTO userDTO, ImageStorageService imageStorageService)
        {
            string imageIdentifier = string.Empty;
            try
            {
                imageIdentifier = imageStorageService.InsertUserImage(userDTO.ProfilePicture);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while inserting image for '{userDTO.Username}' user! Empty string inserted");
            }
            return new User()
            {
                UserID = userDTO.ID,
                Username = userDTO.Username,
                Email = userDTO.Email,
                ProfilePictureURI = imageIdentifier,
            };
        }

        public static User ToUser(this CreateUserDTO userDTO)
        {
            return new User()
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password
            };
        }

        public static User ToUser(this UpdateUserDTO userDTO)
        {
            return new User()
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password
            };
        }
    }
}
