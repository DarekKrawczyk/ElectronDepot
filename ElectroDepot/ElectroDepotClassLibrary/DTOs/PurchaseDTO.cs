namespace ElectroDepotClassLibrary.DTOs
{
    public record PurchaseDTO(
        int ID,
        int UserID,
        int SupplierID,
        DateTime PurchaseDate,
        double TotalPrice
    );

    public record CreatePurchaseDTO(
        int UserID,
        int SupplierID,
        DateTime PurchaseDate,
        double TotalPrice
    );
    public record UpdatePurchaseDTO(
        DateTime PurchaseDate,
        double TotalPrice
    );

    public static class PurchaseDTOExtentionMethods
    {
        public static UpdatePurchaseDTO ToUpdatePurchaseDTO(this PurchaseDTO purchaseDTO)
        {
            return new UpdatePurchaseDTO(TotalPrice: purchaseDTO.TotalPrice, PurchaseDate: purchaseDTO.PurchaseDate);
        }
    }
}
