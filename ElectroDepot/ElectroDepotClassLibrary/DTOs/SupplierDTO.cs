namespace ElectroDepotClassLibrary.DTOs
{
    public record SupplierDTO(
        int ID,
        string Name,
        string Website
    );

    public record CreateSupplierDTO(
        string Name,
        string Website
    );

    public record UpdateSupplierDTO(
        string Name,
        string Website
    );

    public static class SupplierDTOExtensionMethods
    {
        public static UpdateSupplierDTO ToUpdateSupplierDTO(this SupplierDTO supplierDTO)
        {
            return new UpdateSupplierDTO(Name: supplierDTO.Name, Website: supplierDTO.Website);
        }
    }
}
