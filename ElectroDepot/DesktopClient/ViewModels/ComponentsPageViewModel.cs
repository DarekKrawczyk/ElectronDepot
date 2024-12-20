using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ElectroDepotClassLibrary.Stores;
using ElectroDepotClassLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using DesktopClient.Containers;
using Avalonia.Collections;
using System.Transactions;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using System.Linq;

namespace DesktopClient.ViewModels
{
    public partial class ComponentsPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> Manufacturers { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public DataGridCollectionView Components { get; set; }
        //public ObservableCollection<DetailedComponentContainer> Components { get; set; }
        public List<DetailedComponentContainer> ComponentsSource { get; set; }

        [ObservableProperty]
        private string _searchByNameOrDesc = string.Empty;

        partial void OnSearchByNameOrDescChanged(string value)
        {
            Console.WriteLine(value);
            Components.Refresh();
        }

        [ObservableProperty]
        private bool _onlyAvailableFlag;

        partial void OnOnlyAvailableFlagChanged(bool value)
        {
            Components.Refresh();
            Console.WriteLine(value);
        }

        [ObservableProperty]
        private string _selectedManufacturer;

        partial void OnSelectedManufacturerChanged(string value)
        {
            Components.Refresh();
            Console.WriteLine($"{value}");
            var user = DatabaseStore.UsersStore.LoggedInUser;
        }

        [ObservableProperty]
        private string _selectedCategory;

        partial void OnSelectedCategoryChanged(string value)
        {
            Components.Refresh();
            Console.WriteLine($"{value}");
        }

        [RelayCommand]
        public void ClearAllFiltersAndSorting()
        {
            SelectedCategory = null;
            SelectedManufacturer = null;
            OnlyAvailableFlag = false;
            SearchByNameOrDesc = string.Empty;
            Components.Refresh();
            Console.WriteLine();
        }

        public ComponentsPageViewModel(DatabaseStore databaseStore) : base(databaseStore)
        {
            ComponentsSource = new List<DetailedComponentContainer>();
            
            Components = new DataGridCollectionView(ComponentsSource);
            Components.Filter = (object component) =>
            {
                if(component is DetailedComponentContainer detailedComponent)
                {
                    bool isManufacturer = true;
                    bool isCategory = true;
                    bool isNameOrDesc = false;
                    bool onlyAvailable = true;
                    
                    if(OnlyAvailableFlag == true)
                    {
                        if (detailedComponent.AvailableAmount <= 0)
                        {
                            onlyAvailable = false;
                        }
                    }

                    if(SelectedManufacturer != null)
                    {
                        if (!detailedComponent.Manufacturer.Contains(SelectedManufacturer, StringComparison.InvariantCultureIgnoreCase))
                        {
                            isManufacturer = false;
                        }
                    }

                    if (SelectedCategory!= null)
                    {
                        if (!detailedComponent.Category.Name.Contains(SelectedCategory, StringComparison.InvariantCultureIgnoreCase))
                        {
                            isCategory = false;
                        }
                    }

                    if (detailedComponent.Name.Contains(_searchByNameOrDesc, StringComparison.InvariantCultureIgnoreCase) ||
                       detailedComponent.Description.Contains(_searchByNameOrDesc, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isNameOrDesc = true;
                    }

                    if(isNameOrDesc == true && isManufacturer == true && isCategory == true && onlyAvailable == true)
                    {
                        return true;
                    }
                }
                return false;
            };

            Manufacturers = new ObservableCollection<string>() { };
            DatabaseStore.ComponentStore.Load();
            DatabaseStore.ComponentStore.ComponentsLoaded += HandleComponentsLoaded;

            Categories = new ObservableCollection<string>() { };
            DatabaseStore.CategorieStore.Load();
            DatabaseStore.CategorieStore.CategoriesLoaded += HandleCategoriesLoaded;
        }

        private void HandleComponentsLoaded()
        {
            Manufacturers.Clear();
            ComponentsSource.Clear();

            IEnumerable<OwnsComponent> ownedComponents = DatabaseStore.ComponentStore.OwnedComponents;
            IEnumerable<OwnsComponent> unusedComponents = DatabaseStore.ComponentStore.UnusedComponents;
            IEnumerable<Component> components = DatabaseStore.ComponentStore.Components;
            for(int i = 0; i < components.Count(); i++)
            {
                Component component = components.ElementAt(i);
                OwnsComponent ownedComponent = ownedComponents.ElementAt(i);
                OwnsComponent unusedComponent = unusedComponents.ElementAt(i);

                ComponentsSource.Add(new DetailedComponentContainer(component, ownedComponent, unusedComponent));
                Manufacturers.Add(component.Manufacturer);
            }
            Components.Refresh();
        }

        private void HandleCategoriesLoaded()
        {
            Categories.Clear();
            IEnumerable<Category> categories = DatabaseStore.CategorieStore.Categories;
            foreach(Category category in categories)
            {
                Categories.Add(category.Name);
            }
        }

        public override void Dispose()
        {
            DatabaseStore.CategorieStore.CategoriesLoaded -= HandleCategoriesLoaded;
            DatabaseStore.ComponentStore.ComponentsLoaded -= HandleComponentsLoaded;
        }
    }
}
