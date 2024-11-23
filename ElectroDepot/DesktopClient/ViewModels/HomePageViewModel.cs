using System;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using DesktopClient.Containers;
using ElectroDepotClassLibrary.Stores;
using ElectroDepotClassLibrary.Models;
using System.Data;

namespace DesktopClient.ViewModels
{
    public partial class HomePageViewModel : ViewModelBase
    {
        public ObservableCollection<SupplierContainer> Suppliers { get; set; }

        public ISeries[] Series { get; set; } = [
            new ColumnSeries<DateTimePoint>
            {
                Values = [
                    new() { DateTime = new(2024, 1, 1), Value = 3 },
                    new() { DateTime = new(2024, 2, 1), Value = 6 },
                    new() { DateTime = new(2024, 3, 1), Value = 5 },
                    new() { DateTime = new(2024, 4, 1), Value = 3 },
                    new() { DateTime = new(2024, 5, 1), Value = 5 },
                    new() { DateTime = new(2024, 6, 1), Value = 8 },
                    new() { DateTime = new(2024, 7, 1), Value = 6 },
                    new() { DateTime = new(2024, 8, 1), Value = 6 },
                    new() { DateTime = new(2024, 9, 1), Value = 6 },
                    new() { DateTime = new(2024, 10, 1), Value = 6 },
                    new() { DateTime = new(2024, 11, 1), Value = 6 },
                    new() { DateTime = new(2024, 12, 1), Value = 6 }
                ],
               Stroke = new SolidColorPaint(SKColors.WhiteSmoke) { StrokeThickness = 30 },
        MaxBarWidth = double.MaxValue,
        Padding = 0
            }
        ];

        // You can use the DateTimeAxis class to define a date time based axis 

        // The first parameter is the time between each point, in this case 1 day 
        // you can also use 1 year, 1 month, 1 hour, 1 minute, 1 second, 1 millisecond, etc 

        // The second parameter is a function that receives a date and returns the label as string 
        public ICartesianAxis[] XAxes { get; set; } = [
            new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("MMM"))
        ];
        
        public HomePageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
            Suppliers = new ObservableCollection<SupplierContainer>();
            DatabaseStore.SupplierStore.SuppliersLoaded += SuppliersLoadedHandler;
            DatabaseStore.SupplierStore.Load();
        }

        private void SuppliersLoadedHandler()
        {
            Suppliers.Clear();
            foreach(Supplier supplier in DatabaseStore.SupplierStore.Suppliers)
            {
                Suppliers.Add(new SupplierContainer(supplier));
            }
        }

        public override void Dispose()
        {
            DatabaseStore.SupplierStore.SuppliersLoaded -= SuppliersLoadedHandler;
        }
    }
}
