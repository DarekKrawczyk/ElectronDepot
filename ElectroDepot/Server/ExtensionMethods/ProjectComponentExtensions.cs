using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class ProjectComponentExtensions
    {
        public static ProjectComponentDTO ToProjectComponentDTO(this ProjectComponent projectComponent)
        {
            return new ProjectComponentDTO(
                ID: projectComponent.ProjectComponentID,
                ComponentID: projectComponent.ComponentID, 
                ProjectID: projectComponent.ProjectID, 
                Quantity: projectComponent.Quantity
            );
        }

        public static ProjectComponent ToProjectComponent(this CreateProjectComponentDTO createProjectComponentDTO)
        {
            return new ProjectComponent()
            {
                ProjectID = createProjectComponentDTO.ProjectID,
                ComponentID = createProjectComponentDTO.ComponentID,
                Quantity = createProjectComponentDTO.Quantity
            };
        }
    }
}
