using ElectroDepotClassLibrary.DTOs;
using Server.Models;
using System.Reflection.Metadata.Ecma335;

namespace Server.ExtensionMethods
{
    public static class PurchaseItemExtensionMethods
    {
        public static PurchaseItemDTO ToPurchaseItemDTO(this PurchaseItem purchaseItem)
        {
            return new PurchaseItemDTO(ID: purchaseItem.PurchaseItemID, PurchaseID: purchaseItem.PurchaseID, ComponentID: purchaseItem.ComponentID, Quantity: purchaseItem.Quantity, PricePerUnit: purchaseItem.PricePerUnit);
        }

        public static PurchaseItem ToPurchase(this CreatePurchaseItemDTO createPurchaseItemDTO)
        {
            return new PurchaseItem()
            {
                PurchaseID = createPurchaseItemDTO.PurchaseID,
                ComponentID = createPurchaseItemDTO.ComponentID,
                Quantity = createPurchaseItemDTO.Quantity,
                PricePerUnit = createPurchaseItemDTO.PricePerUnit
            };
        }
    }
}
