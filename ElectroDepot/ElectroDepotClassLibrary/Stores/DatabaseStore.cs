using ElectroDepotClassLibrary.DataProviders;

namespace ElectroDepotClassLibrary.Stores
{
    public class DatabaseStore
    {
        private SuppliersStore _supplierStore;
        public SuppliersStore SupplierStore
        {
            get
            {
                return _supplierStore;
            }
        }
        public DatabaseStore(SupplierDataProvider supplierDataProvider)
        {
            _supplierStore = new SuppliersStore(supplierDataProvider);
        }
    }
}
