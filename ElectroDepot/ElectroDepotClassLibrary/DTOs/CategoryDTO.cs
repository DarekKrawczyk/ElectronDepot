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

    public static class CategoryDTOsExtensions
    {
        public static CreateCategoryDTO ToCreateCategoryDTO(this CategoryDTO categoryDTO)
        {
            return new CreateCategoryDTO(Name: categoryDTO.Name, Description: categoryDTO.Description, Image: categoryDTO.Image);
        }

        public static UpdateCategoryDTO ToUpdateCategoryDTO(this CategoryDTO categoryDTO)
        {
            return new UpdateCategoryDTO(Name: categoryDTO.Name, Description: categoryDTO.Description, Image: categoryDTO.Image);
        }
    }
}
