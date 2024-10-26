using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class SuppliersExtensionMethods
    {
        public static Supplier ToSupplier(this SupplierDTO supplierDTO)
        {
            return new Supplier()
            {
                SupplierID = supplierDTO.ID,
                Name = supplierDTO.Name,
                Website = supplierDTO.Website
            };
        }

        public static Supplier ToSupplier(this CreateSupplierDTO supplierDTO)
        {
            return new Supplier()
            {
                Name = supplierDTO.Name,
                Website = supplierDTO.Website
            };
        }

        public static SupplierDTO ToSupplierDTO(this Supplier supplier)
        {
            return new SupplierDTO(ID: supplier.SupplierID, Name: supplier.Name, Website: supplier.Website);
        }
    }
}
