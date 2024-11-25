using ElectroDepotClassLibrary.Stores;

namespace DesktopClient.ViewModels
{
    public class PurchasesPageViewModel : ViewModelBase
    {
        public PurchasesPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
        }

        public override void Dispose()
        {
        }
    }
}
