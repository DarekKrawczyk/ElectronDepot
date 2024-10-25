namespace ElectroDepotClassLibrary.Endpoints
{
    public static class CategoryEndpoints
    {
        public static string Create() => "ElectroDepot/Categories/Create";
        public static string GetAll() => "ElectroDepot/Categories/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/Categories/GetCategoryByID/{ID}";
        public static string GetByName(string Name) => $"ElectroDepot/Categories/GetCategoryByName/{Name}";
        public static string Update(int ID) => $"ElectroDepot/Categories/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/Categories/Delete/{ID}";
    }
}
