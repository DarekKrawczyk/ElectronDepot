using CommunityToolkit.Mvvm.ComponentModel;
using ElectroDepotClassLibrary.Stores;
using System;

namespace DesktopClient.ViewModels
{
    public abstract class ViewModelBase : ObservableObject, IDisposable
    {
        protected DatabaseStore DatabaseStore { get; }
        public ViewModelBase(DatabaseStore databaseStore)
        {
            DatabaseStore = databaseStore;
        }

        public abstract void Dispose();
    }
}
