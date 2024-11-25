namespace ElectroDepotClassLibrary.DTOs
{
    public record ProjectDTO(
        int ID,
        int UserID,
        string Name,
        string Description,
        DateTime CreatedAt,
        byte[] Image
    );

    public record CreateProjectDTO(
        int UserID,
        string Name,
        string Description,
        byte[] Image
    );

    public record UpdateProjectDTO(
        string Name,
        string Description,
        byte[] Image
    );
}