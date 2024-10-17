namespace ElectroDepotClassLibrary.Endpoints
{
    public static class CategoryEndpoints
    {
        public static string Create() => "ElectronDepot/Categories/Create";
        public static string GetAll() => "ElectronDepot/Categories/GetAll";
        public static string GetByID(int ID) => $"ElectronDepot/Categories/GetCategoryByID/{ID}";
        public static string GetByName(string Name) => $"ElectronDepot/Categories/GetCategoryByName/{Name}";
        public static string Update(int ID) => $"ElectronDepot/Categories/Update/{ID}";
        public static string Delete(int ID) => $"ElectronDepot/Categories/Delete/{ID}";
    }
}
