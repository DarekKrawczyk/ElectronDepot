using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElectroDepotClassLibrary.Models;
using System;
using System.Diagnostics;

namespace DesktopClient.Containers
{
    public partial class ComponentContainer : ObservableObject
    {
        public Component Component { get; set; }
        
        public ComponentContainer(Component component)
        {
            Component = component;
        }

        [RelayCommand]
        private void ItemClicked()
        {
            Console.WriteLine("Clicked at ->: " + Component);
        }

    }
}
