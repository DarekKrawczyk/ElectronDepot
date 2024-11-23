using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.Stores
{
    public class SuppliersStore
    {
        private readonly SupplierDataProvider _supplierDataProvider;
        private List<Supplier> _suppliers;

        public IEnumerable<Supplier> Suppliers
        {
            get
            {
                return _suppliers;
            }
        }

        public event Action SuppliersLoaded;

        public SuppliersStore(SupplierDataProvider supplierDataProvider)
        {
            _supplierDataProvider = supplierDataProvider;
            _suppliers = new List<Supplier>();
        }

        public async Task Load()
        {
            _suppliers.Clear();

            IEnumerable<Supplier> suppliersFromDB = await _supplierDataProvider.GetAllSuppliers();
            _suppliers.AddRange(suppliersFromDB);

            SuppliersLoaded?.Invoke();
        }
    }
}
