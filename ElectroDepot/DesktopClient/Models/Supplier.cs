using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;

namespace DesktopClient.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public Bitmap Image { get; set; } // For now we are using AvaloniaUI but in future we need to think about how to store it in DB.
        public Supplier(int id, string name, string website, Bitmap image)
        {
            ID = id;
            Name = name;
            Website = website;
            Image = image;
        }
    }

    public partial class SupplierContainer : ObservableObject
    {
        public Supplier Supplier { get; set; }

        [RelayCommand]
        private void ItemClicked()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Supplier.Website,
                UseShellExecute = true
            });
        }

        public SupplierContainer(Supplier supplier)
        {
            Supplier = supplier;
        }
    }
}
