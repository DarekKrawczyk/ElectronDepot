using System.ComponentModel.DataAnnotations;

namespace ElectroDepotClassLibrary.DTOs
{
    public record CategoryDTO(
        int ID,
        string Name,
        string Description
    );

    public record CreateCategoryDTO(
        [Required] 
        string Name,
        string Description
    );

    public record UpdateCategoryDTO(
        [Required]
        string Name,
        string Description
);
}
