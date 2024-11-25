using System.ComponentModel.DataAnnotations;

namespace ElectroDepotClassLibrary.DTOs
{
    public record CategoryDTO(
        int ID,
        string Name,
        string Description,
        byte[] Image
    );

    public record CreateCategoryDTO(
        [Required] 
        string Name,
        string Description,
        byte[] Image
    );

    public record UpdateCategoryDTO(
        [Required]
        string Name,
        string Description,
        byte[] Image
    );
}