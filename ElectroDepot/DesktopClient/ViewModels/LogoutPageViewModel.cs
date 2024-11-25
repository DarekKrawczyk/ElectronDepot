using ElectroDepotClassLibrary.Stores;

namespace DesktopClient.ViewModels
{
    public class LogoutPageViewModel : ViewModelBase
    {
        public LogoutPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
        }

        public override void Dispose()
        {
        }
    }
}
