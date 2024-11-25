using Avalonia.Media.Imaging;
using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Utility;

namespace ElectroDepotClassLibrary.Models
{
    public class User
    {
        public int ID { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Bitmap ProfilePicture { get; set; }
        public User(int id, string username, string password, string email, Bitmap profilePicture)
        {
            ID = id;
            Username = username;
            Email = email;
            Password = password;
            ProfilePicture = profilePicture;
        }
        public override string ToString()
        {
            return $"ID: '{ID}', Username: '{Username}', Email: '{Email}'";
        }
    }

    internal static class UserExtensionMethods
    {
        internal static UserDTO ToDTO(this User user)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                imageAsBytes = ImageConverterUtility.BitmapToBytes(user.ProfilePicture);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Bitmap to Byte[] for '{user.Username}' user!");
            }
            return new UserDTO(
                ID: user.ID,
                Username: user.Username,
                Email: user.Email,
                ProfilePicture: imageAsBytes);
        }

        internal static UpdateUserDTO ToUpdateDTO(this User user)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                imageAsBytes = ImageConverterUtility.BitmapToBytes(user.ProfilePicture);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Bitmap to Byte[] for '{user.Username}' user!");
            }
            return new UpdateUserDTO(
                Username: user.Username,
                Email: user.Email,
                Password: user.Password,
                ProfilePicture: imageAsBytes);
        }

        internal static CreateUserDTO ToCreateDTO(this User user)
        {
            byte[] imageAsBytes = new byte[] { };
            try
            {
                imageAsBytes = ImageConverterUtility.BitmapToBytes(user.ProfilePicture);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Bitmap to Byte[] for '{user.Username}' user!");
            }
            return new CreateUserDTO(
                Username: user.Username,
                Password: user.Password,
                Email: user.Email,
                ProfilePicture: imageAsBytes);
        }

        internal static User ToModel(this UserDTO userDTO)
        {
            Bitmap bitmap = null;
            try
            {
                bitmap = ImageConverterUtility.BytesToBitmap(userDTO.ProfilePicture);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception while paring Byte[] to Bitmap for '{userDTO.Username}' user!");
            }
            return new User(
                id: userDTO.ID,
                username: userDTO.Username,
                email: userDTO.Email,
                profilePicture: bitmap,
                password: string.Empty);
        }
    }
}
