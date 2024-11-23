using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElectroDepotClassLibrary.Models;

namespace DesktopClient.Containers
{
    public partial class ProjectContainer : ObservableObject
    {
        public Project Project { get; set; }

        public ProjectContainer(Project project)
        {
            Project = project;
        }

        [RelayCommand]
        private void ItemClicked()
        {
            Console.WriteLine("Clicked at ->: " + Project);
        }
    }
}
