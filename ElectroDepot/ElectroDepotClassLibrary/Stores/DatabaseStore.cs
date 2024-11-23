using ElectroDepotClassLibrary.DataProviders;

namespace ElectroDepotClassLibrary.Stores
{
    public class DatabaseStore
    {
        private SuppliersStore _supplierStore;
        private ComponentsStore _componentsStore;
        private CategoriesStore _categoriesStore;
        public SuppliersStore SupplierStore
        {
            get
            {
                return _supplierStore;
            }
        }

        public ComponentsStore ComponentStore
        {
            get
            {
                return _componentsStore;
            }
        }

        public CategoriesStore CategoriesStore
        {
            get
            {
                return _categoriesStore;
            }
        }

        public DatabaseStore(SupplierDataProvider supplierDataProvider, ComponentDataProvider componentDataProvider, CategoryDataProvider categoryDataProvider)
        {
            _supplierStore = new SuppliersStore(supplierDataProvider);
            _componentsStore = new ComponentsStore(componentDataProvider);
            _categoriesStore = new CategoriesStore(categoryDataProvider);
        }
    }
}
