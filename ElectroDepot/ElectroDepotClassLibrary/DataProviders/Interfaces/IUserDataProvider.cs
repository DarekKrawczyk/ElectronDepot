using ElectroDepotClassLibrary.DTOs;

namespace ElectroDepotClassLibrary.DataProviders.Interfaces
{
    public interface IUserDataProvider
    {
        Task<bool> CreateUser(CreateUserDTO user);
        Task<bool> DeleteUser(int ID);
        Task<bool> DeleteUser(UserDTO user);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserByEMail(string EMail);
        Task<UserDTO> GetUserByID(int ID);
        Task<UserDTO> GetUserByUsername(string name);
        Task<bool> UpdateUser(int UserID, UpdateUserDTO user);
        Task<bool> UserWithEMailExists(string EMail);
        Task<bool> UserWithUsernameExists(string username);
    }
}