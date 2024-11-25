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
}