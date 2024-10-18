using System.ComponentModel.DataAnnotations;

namespace ElectroDepotClassLibrary.DTOs
{
    public record ComponentDTO(
        int ID,
        int CategoryID,
        string Name,
        string Manufacturer,
        string Description
    );

    public record CreateComponentDTO(
        [Required]
        int CategoryID,
        string Name,
        string Manufacturer,
        string Description
    );

    public record UpdateComponentDTO(
        string Name,
        string Manufacturer,
        string Description
    );

    public static class ComponentDTOsExtensions
    {
        public static CreateComponentDTO ToCreateComponentDTO(this ComponentDTO componentDTO)
        {
            return new CreateComponentDTO(CategoryID: componentDTO.CategoryID, Name: componentDTO.Name, Manufacturer: componentDTO.Manufacturer, Description: componentDTO.Description);
        }

        public static UpdateComponentDTO ToUpdateComponentDTO(this ComponentDTO componentDTO)
        {
            return new UpdateComponentDTO(Name: componentDTO.Name, Manufacturer: componentDTO.Manufacturer, Description: componentDTO.Description);
        }
    }
}
