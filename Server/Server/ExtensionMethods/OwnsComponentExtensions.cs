using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class OwnsComponentExtensions
    {
        public static OwnsComponentDTO ToDTO(this OwnsComponent component)
        {
            return new OwnsComponentDTO(
                ID: component.ComponentID, 
                UserID: component.UserID, 
                ComponentID: component.ComponentID, 
                Quantity: component.Quantity);
        }

        public static OwnsComponent ToOwnComponent(this OwnsComponentDTO componentDTO)
        {
            return new OwnsComponent()
            {
                OwnsComponentID = componentDTO.ID,
                UserID = componentDTO.UserID,
                ComponentID = componentDTO.ComponentID,
                Quantity = componentDTO.Quantity
            };
        }

        public static OwnsComponent ToOwnComponent(this CreateOwnsComponentDTO componentDTO)
        {
            return new OwnsComponent()
            {
                UserID = componentDTO.UserID,
                ComponentID = componentDTO.ComponentID,
                Quantity = componentDTO.Quantity
            };
        }

        public static OwnsComponent ToOwnComponent(this UpdateOwnsComponentDTO componentDTO)
        {
            return new OwnsComponent()
            {
                Quantity = componentDTO.Quantity
            };
        }
    }
}
