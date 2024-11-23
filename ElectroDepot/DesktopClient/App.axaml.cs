using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using DesktopClient.ViewModels;
using DesktopClient.Views;
using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Stores;

namespace DesktopClient
{
    public partial class App : Application
    {
        public string ConnectionURL { get { return "https://localhost:7146/"; } }
        private DatabaseStore _databaseStore;
        public override void Initialize()
        {
            SupplierDataProvider supplierDataProvider = new SupplierDataProvider(ConnectionURL);
            _databaseStore = new DatabaseStore(supplierDataProvider);

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(_databaseStore),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}