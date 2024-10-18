namespace ElectroDepotClassLibrary.Endpoints
{
    public static class ComponentEndpoints
    {
        public static string Create() => "ElectronDepot/Components/Create";
        public static string GetAll() => "ElectronDepot/Components/GetAll";
        public static string GetByID(int ID) => $"ElectronDepot/Components/GetComponentByID/{ID}";
        public static string GetByName(string Name) => $"ElectronDepot/Components/GetComponentByName/{Name}";
        public static string Update(int ID) => $"ElectronDepot/Components/Update/{ID}";
        public static string Delete(int ID) => $"ElectronDepot/Components/Delete/{ID}";
    }
}
