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

    public static class CategoryDTOsExtensions
    {
        public static CreateCategoryDTO ToCreateCategoryDTO(this CategoryDTO categoryDTO)
        {
            return new CreateCategoryDTO(Name: categoryDTO.Name, Description: categoryDTO.Description);
        }

        public static UpdateCategoryDTO ToUpdateCategoryDTO(this CategoryDTO categoryDTO)
        {
            return new UpdateCategoryDTO(Name: categoryDTO.Name, Description: categoryDTO.Description);
        }
    }
}
