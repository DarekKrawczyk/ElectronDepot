namespace ElectroDepotClassLibrary.DTOs
{
    public record UserDTO(
        int ID,
        string Username,
        string Email,
        byte[] ProfilePicture
    );

    public record CreateUserDTO(
        string Username,
        string Email,
        string Password,
        byte[] ProfilePicture
    );

    public record UpdateUserDTO(
        string Username,
        string Email,
        string Password,
        byte[] ProfilePicture
    );
}