using ElectroDepotClassLibrary.Stores;

namespace DesktopClient.ViewModels
{
    public class ProjectsPageViewModel : ViewModelBase
    {
        public ProjectsPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
        }

        public override void Dispose()
        {
        }
    }
}
