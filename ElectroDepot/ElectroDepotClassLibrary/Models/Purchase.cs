using ElectroDepotClassLibrary.DTOs;

namespace ElectroDepotClassLibrary.Models
{
    public class Purchase
    {
        public int ID { get; }
        public int UserID { get; }
        public User User { get; }
        public int SupplierID { get; }
        public Supplier Supplier { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalPrice { get; set; }
        public Purchase(int iD, int userID, User user, int supplierID, Supplier supplier, DateTime purchaseDate, double totalPrice)
        {
            ID = iD;
            UserID = userID;
            User = user;
            SupplierID = supplierID;
            Supplier = supplier;
            PurchaseDate = purchaseDate;
            TotalPrice = totalPrice;
        }
        public override string ToString()
        {
            return $"ID: '{ID}', UserID: '{UserID}', SupplierID: '{SupplierID}', PurchaseDate: '{PurchaseDate}', TotalPrice: '{TotalPrice}'";
        }

        public PurchaseDTO ToDTO()
        {
            return new PurchaseDTO(ID: ID, UserID: UserID, SupplierID: SupplierID, PurchaseDate: PurchaseDate, TotalPrice: TotalPrice);
        }

        public UpdatePurchaseDTO ToUpdateDTO()
        {
            return new UpdatePurchaseDTO(PurchaseDate: PurchaseDate, TotalPrice: TotalPrice);
        }

        public CreatePurchaseDTO ToCreateDTO()
        {
            return new CreatePurchaseDTO(UserID: UserID, SupplierID: SupplierID, PurchaseDate: PurchaseDate, TotalPrice: TotalPrice);
        }
    }

    public static class PurchaseExtensionMethods
    {
        public static Purchase ToModel(this PurchaseDTO purchaseDTO)
        {
            return new Purchase(iD: purchaseDTO.ID, userID: purchaseDTO.UserID, user: null, supplierID: purchaseDTO.SupplierID, supplier: null, purchaseDate: purchaseDTO.PurchaseDate, totalPrice: purchaseDTO.TotalPrice);
        }
    }
}
