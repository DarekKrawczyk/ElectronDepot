namespace ElectroDepotClassLibrary.Endpoints
{
    public static class PurchaseEndpoints
    {
        public static string Create() => "ElectroDepot/Purchases/Create";
        public static string GetAll() => "ElectroDepot/Purchases/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/Purchases/GetByID/{ID}";
        public static string GetAllByUserID(int ID) => $"ElectroDepot/Purchases/GetAllByUserID/{ID}";
        public static string GetAllBySupplierID(int ID) => $"ElectroDepot/Purchases/GetAllBySupplierID/{ID}";
        public static string Update(int ID) => $"ElectroDepot/Purchases/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/Purchases/Delete/{ID}";
    }
}
