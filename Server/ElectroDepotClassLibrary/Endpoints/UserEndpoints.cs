namespace ElectroDepotClassLibrary.Endpoints
{
    public static class UserEndpoints
    {
        public static string Create() => "ElectronDepot/Users/Create";
        public static string GetAll() => "ElectronDepot/Users/GetAll";
        public static string GetByID(int ID) => $"ElectronDepot/Users/GetUserByID/{ID}";
        public static string GetByUsername(string Name) => $"ElectronDepot/Users/GetUserByUsername/{Name}";
        public static string GetByEMail(string EMail) => $"ElectronDepot/Users/GetUserByEMail/{EMail}";
        public static string Update(int ID) => $"ElectronDepot/Users/Update/{ID}";
        public static string Delete(int ID) => $"ElectronDepot/Users/Delete/{ID}";
    }
}
