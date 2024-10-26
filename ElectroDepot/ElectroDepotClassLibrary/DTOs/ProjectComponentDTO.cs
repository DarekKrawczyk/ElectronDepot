using System.Diagnostics;

namespace ElectroDepotClassLibrary.DTOs
{
    public record ProjectComponentDTO(
        int ID,
        int ComponentID,
        int ProjectID,
        int Quantity
    );

    public record CreateProjectComponentDTO(
        int ComponentID,
        int ProjectID,
        int Quantity
    );

    public record UpdateProjectComponentDTO(
        int Quantity
    );

    public static class ProjectComponentExtensionMethods
    {
        public static UpdateProjectComponentDTO ToUpdateProjectComponentDTO(this ProjectComponentDTO projectComponent)
        {
            return new UpdateProjectComponentDTO(Quantity: projectComponent.Quantity);
        }
    }
}