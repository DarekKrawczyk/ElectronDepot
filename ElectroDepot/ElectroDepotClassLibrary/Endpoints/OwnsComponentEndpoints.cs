namespace ElectroDepotClassLibrary.Endpoints
{
    public static class OwnsComponentEndpoints
    {
        public static string Create() => "ElectroDepot/OwnsComponents/Create";
        public static string GetAll() => "ElectroDepot/OwnsComponents/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/OwnsComponents/GetUserByID/{ID}";
        public static string Update(int ID) => $"ElectroDepot/OwnsComponents/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/OwnsComponents/Delete/{ID}";
    }
}
