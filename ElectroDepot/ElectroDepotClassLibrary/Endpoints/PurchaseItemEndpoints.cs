namespace ElectroDepotClassLibrary.Endpoints
{
    public static class PurchaseItemEndpoints
    {
        public static string Create() => "ElectroDepot/PurchaseItems/Create";
        public static string GetAll() => "ElectroDepot/PurchaseItems/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/PurchaseItems/GetByID/{ID}";
        public static string Update(int ID) => $"ElectroDepot/PurchaseItems/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/PurchaseItems/Delete/{ID}";
    }
}
