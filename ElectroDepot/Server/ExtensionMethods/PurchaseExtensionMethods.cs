using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class PurchaseExtensionMethods
    {
        public static Purchase ToPurchase(this CreatePurchaseDTO createPurchaseDTO)
        {
            return new Purchase()
            {
                UserID = createPurchaseDTO.UserID,
                SupplierID = createPurchaseDTO.SupplierID,
                PurchasedDate = createPurchaseDTO.PurchaseDate,
                TotalPrice = createPurchaseDTO.TotalPrice
            };
        }

        public static PurchaseDTO ToPurchaseDTO(this Purchase purchase)
        {
            return new PurchaseDTO(ID: purchase.PurchaseID, UserID: purchase.UserID, SupplierID: purchase.SupplierID, PurchaseDate: purchase.PurchasedDate, TotalPrice: purchase.TotalPrice);
        }
        public static UpdatePurchaseDTO ToUpdatePurchaseDTO(this Purchase purchase)
        {
            return new UpdatePurchaseDTO(PurchaseDate: purchase.PurchasedDate, TotalPrice: purchase.TotalPrice);
        }
        public static Purchase ToPurchase(this UpdatePurchaseDTO purchase)
        {
            return new Purchase()
            {
                PurchasedDate = purchase.PurchaseDate,
                TotalPrice = purchase.TotalPrice
            };
        }
    }
}
