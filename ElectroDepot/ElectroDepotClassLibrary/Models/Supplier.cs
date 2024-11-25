using Avalonia.Media.Imaging;
using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Utility;

namespace ElectroDepotClassLibrary.Models
{
    public class Supplier
    {
        public int ID { get; }
        public string Name { get; set; } 
        public string Website { get; set; }
        public byte[] ByteImage { get; set; }
        public Bitmap Image
        {
            get
            {
                return ImageConverterUtility.BytesToBitmap(ByteImage);
            }
            set
            {
                ByteImage = ImageConverterUtility.BitmapToBytes(value);
            }
        }

        public Supplier(int id, string name, string website, byte[] image)
        {
            ID = id;
            Name = name;
            Website = website;
            ByteImage = image;
        }

        public override string ToString()
        {
            return $"ID: '{ID}', Name: '{Name}', Website: '{Website}'";
        }
    }

    public static class SupplierExtensionMethods
    {
        public static SupplierDTO ToDTO(this Supplier supplier)
        {
            return new SupplierDTO(ID: supplier.ID, Name: supplier.Name, Website: supplier.Website, Image: supplier.ByteImage);
        }
        public static UpdateSupplierDTO ToUpdateDTO(this Supplier supplier)
        {
            return new UpdateSupplierDTO(Name: supplier.Name, Website: supplier.Website, Image: supplier.ByteImage);
        }
        public static CreateSupplierDTO ToCreateDTO(this Supplier supplier)
        {
            return new CreateSupplierDTO(Name: supplier.Name, Website: supplier.Website, Image: supplier.ByteImage);
        }
        public static Supplier ToModel(this SupplierDTO supplierDTO)
        {
            return new Supplier(id: supplierDTO.ID, name: supplierDTO.Name, website: supplierDTO.Website, image: supplierDTO.Image);
        }
    }
}
