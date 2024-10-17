using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class ComponentExtensions
    {
        public static ComponentDTO ToDTO(this Component component)
        {
            return new ComponentDTO(
                component.ComponentID,
                component.CategoryID,
                component.Name,
                component.Manufacturer,
                component.Description
            );
        }

        public static Component ToCategory(this ComponentDTO componentDTO)
        {
            return new Component()
            {
                ComponentID = componentDTO.ID,
                CategoryID = componentDTO.CategoryID,
                Name = componentDTO.Name,
                Manufacturer = componentDTO.Manufacturer,
                Description = componentDTO.Description
            };
        }

        public static Component ToCategory(this CreateComponentDTO componentDTO)
        {
            return new Component()
            {
                CategoryID = componentDTO.CategoryID,
                Name = componentDTO.Name,
                Manufacturer = componentDTO.Manufacturer,
                Description = componentDTO.Description
            };
        }

        public static Component ToCategory(this UpdateComponentDTO componentDTO)
        {
            return new Component()
            {
                Name = componentDTO.Name,
                Manufacturer = componentDTO.Manufacturer,
                Description = componentDTO.Description
            };
        }
    }
}
