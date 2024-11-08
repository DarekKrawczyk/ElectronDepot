using Avalonia.Media.Imaging;
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
            new ListItemTemplate(typeof(ComponentsPageViewModel)),
            new ListItemTemplate(typeof(ProjectsPageViewModel)),
            new ListItemTemplate(typeof(PurchasesPageViewModel)),
            new ListItemTemplate(typeof(MonitoringPageViewModel)),
        };

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();
    }

    public class ListItemTemplate
    {
        public Bitmap Icon { get; }    
        public string Label { get; }
        public Type ModelType { get; }
        public ListItemTemplate(Type modelType)
        {
            Label = modelType.Name.Replace("PageViewModel", "");
            Icon = ImageHelper.LoadFromResource(new Uri($"avares://DesktopClient/Assets/{Label}_icon.png"));
            ModelType = modelType;
        }
    }
}
