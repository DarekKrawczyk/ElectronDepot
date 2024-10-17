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
        //public static string ToString(this ComponentDTO component)
        //{
        //    return $"Component: ID'{component.ID}' CategoryID'{component.CategoryID}' Name'{component.Name}' Manufacturer'{component.Manufacturer}' Description'{component.Description}'";
        //}

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
