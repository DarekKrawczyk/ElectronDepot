namespace ElectroDepotClassLibrary.Endpoints
{
    public static class PurchaseItemEndpoints
    {
        public static string Create() => "ElectroDepot/PurchaseItems/Create";
        public static string GetAll() => "ElectroDepot/PurchaseItems/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/PurchaseItems/GetByID/{ID}";
        public static string GetAllComponentsFromPurchase(int PurchaseID) => $"ElectroDepot/PurchaseItems/GetComponentsFromPurchase/{PurchaseID}";
        public static string GetAllPurchaseItemsFromPurchase(int PurchaseID) => $"ElectroDepot/PurchaseItems/GetAllPurchaseItemsFromPurchase/{PurchaseID}";
        public static string Update(int ID) => $"ElectroDepot/PurchaseItems/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/PurchaseItems/Delete/{ID}";
    }
}
