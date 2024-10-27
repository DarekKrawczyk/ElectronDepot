﻿namespace ElectroDepotClassLibrary.Endpoints
{
    public static class ProjectEndpoints
    {
        public static string Create() => "ElectroDepot/Projects/Create";
        public static string GetAll() => "ElectroDepot/Projects/GetAll";
        public static string GetAllOfUser(int ID) => $"ElectroDepot/Projects/GetAllOfUser/{ID}";
        public static string GetByID(int ID) => $"ElectroDepot/Projects/GetUserByID/{ID}";
        public static string Update(int ID) => $"ElectroDepot/Projects/Update/{ID}";
        public static string Delete(int ID) => $"ElectroDepot/Projects/Delete/{ID}";
    }
}