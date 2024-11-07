namespace ElectroDepotClassLibrary.Endpoints
{
    public static class OwnsComponentEndpoints
    {
        public static string Create() => "ElectroDepot/OwnsComponents/Create";
        public static string GetAll() => "ElectroDepot/OwnsComponents/GetAll";
        public static string GetByID(int ID) => $"ElectroDepot/OwnsComponents/GetUserByID/{ID}";
        public static string GetAllOwnComponentFromUser(int UserID) => $"ElectroDepot/OwnsComponents/GetAllOwnComponentFromUser/{UserID}";
        public static string GetAllFreeToUseFromUser(int UserID) => $"ElectroDepot/OwnsComponents/GetAllFreeToUseFromUser/{UserID}";
        public static string GetOwnComponentFromUser(int UserID, int ComponentID) => $"ElectroDepot/OwnsComponents/GetOwnComponentFromUser/{UserID}/Component/{ComponentID}";
        public static string Update(int ID) => $"ElectroDepot/OwnsComponents/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/OwnsComponents/Delete/{ID}";
    }
}
