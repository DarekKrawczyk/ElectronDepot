using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace DesktopClient.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isPanelOpen = true;

        [RelayCommand]
        private void TriggerPane()
        {
            IsPanelOpen = !IsPanelOpen;
        }

        public ObservableCollection<ListItemTemplate> Items { get; set; } = new()
        {
            new ListItemTemplate(typeof(HomePageViewModel)),
            new ListItemTemplate(typeof(ComponentsViewModel)),
            new ListItemTemplate(typeof(ProjectsViewModel)),
            new ListItemTemplate(typeof(PurchasesViewModel)),
            new ListItemTemplate(typeof(MonitoringViewModel)),
        };

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();
    }

    public class ListItemTemplate
    {
        public string Label { get; }
        public Type ModelType { get; }
        public ListItemTemplate(Type modelType)
        {
            Label = modelType.Name.Replace("PageViewModel", "");
            ModelType = modelType;
        }
    }
}
