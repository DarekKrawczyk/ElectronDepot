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
}