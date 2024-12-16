using ElectroDepotClassLibrary.Stores;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using ElectroDepotClassLibrary.Models;

namespace DesktopClient.ViewModels
{
    public class ComponentsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Component> Components { get; } = new ObservableCollection<Component>(
            new List<Component>
            {
                new Component(0, 0, new Category(0, "First", "D1", new byte[]{ }), "Component", "Analog Devices", "Description"),
                new Component(1, 0, new Category(0, "Second", "D2", new byte[]{ }), "Component", "Texas Instruments", "Description"),
                new Component(2, 0, new Category(0, "Third", "D3", new byte[]{ }), "Component", "Microchip", "Description"),
                new Component(3, 0, new Category(0, "Forth", "D4", new byte[]{ }), "Component", "Raspberry Pi", "Description")
            }
        );
        public ComponentsPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {

        }

        public override void Dispose()
        {
        }
    }
}
