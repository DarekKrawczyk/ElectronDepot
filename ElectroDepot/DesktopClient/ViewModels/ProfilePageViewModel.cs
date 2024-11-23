using ElectroDepotClassLibrary.Stores;

namespace DesktopClient.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        public ProfilePageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
        }

        public override void Dispose()
        {
        }
    }
}
