using ElectroDepotClassLibrary.Stores;

namespace DesktopClient.ViewModels
{
    public class MonitoringPageViewModel : ViewModelBase
    {
        public MonitoringPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
        }

        public override void Dispose()
        {
        }
    }
}
