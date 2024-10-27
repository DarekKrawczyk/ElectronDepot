namespace ElectroDepotClassLibrary.DTOs
{
    public record PurchaseItemDTO(
        int ID,
        int PurchaseID,
        int ComponentID,
        int Quantity,
        double PricePerUnit
    );

    public record CreatePurchaseItemDTO(
        int PurchaseID,
        int ComponentID,
        int Quantity,
        double PricePerUnit
    );

    public record UpdatePurchaseItemDTO(
        int Quantity,
        double PricePerUnit
    );

    public static class PurchaseItemDTOExtensionMethods
    {
        public static UpdatePurchaseItemDTO ToUpdatePurchaseItemDTO(this PurchaseItemDTO purchaseItemDTO)
        {
            return new UpdatePurchaseItemDTO(Quantity: purchaseItemDTO.Quantity, PricePerUnit: purchaseItemDTO.PricePerUnit);
        }
    }
}
