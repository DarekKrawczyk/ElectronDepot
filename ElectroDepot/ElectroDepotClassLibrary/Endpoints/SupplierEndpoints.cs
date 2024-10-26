namespace ElectroDepotClassLibrary.Endpoints
{
    public static class SupplierEndpoints
    {
        public static string Create() => "ElectroDepot/Suppliers/Create";
        public static string GetAll() => "ElectroDepot/Suppliers/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/Suppliers/GetByID/{ID}";
        public static string GetByName(string Name) => $"ElectroDepot/Suppliers/GetByName/{Name}";
        public static string Update(int ID) => $"ElectroDepot/Suppliers/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/Suppliers/Delete/{ID}";
    }
}
