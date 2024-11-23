using ElectroDepotClassLibrary.Stores;

namespace DesktopClient.ViewModels
{
    public class ComponentsPageViewModel : ViewModelBase
    {
        public ComponentsPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
        }

        public override void Dispose()
        {
        }
    }
}
