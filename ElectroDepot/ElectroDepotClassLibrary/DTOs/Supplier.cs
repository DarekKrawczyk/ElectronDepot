namespace ElectroDepotClassLibrary.DTOs
{
    public record SupplierDTO(
        int ID,
        string Name,
        string Website,
        byte[] Image
    );

    public record CreateSupplierDTO(
        string Name,
        string Website,
        byte[] Image
    );

    public record UpdateSupplierDTO(
        string Name,
        string Website,
        byte[] Image
    );

    public static class SupplierDTOExtensionMethods
    {
        public static UpdateSupplierDTO ToUpdateSupplierDTO(this SupplierDTO supplierDTO)
        {
            return new UpdateSupplierDTO(Name: supplierDTO.Name, Website: supplierDTO.Website, Image: supplierDTO.Image);
        }
    }
}
