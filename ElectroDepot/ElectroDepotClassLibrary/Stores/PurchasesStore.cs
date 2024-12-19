using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.Stores
{
    public class PurchasesStore : RootStore
    {
        private readonly PurchaseDataProvider _purchaseDataProvider;
        private List<Purchase> _purchases;

        public IEnumerable<Purchase> Purchases { get { return _purchases; } }
        public PurchaseDataProvider DB { get { return _purchaseDataProvider; } }

        public event Action PurchasesLoaded;

        public PurchasesStore(DatabaseStore dbStore, PurchaseDataProvider purchaseDataProvider) : base(dbStore)
        {
            _purchaseDataProvider = purchaseDataProvider;
            _purchases = new List<Purchase>();
        }

        public async Task Load()
        {
            _purchases.Clear();

            IEnumerable<Purchase> purchasesFromDB = await _purchaseDataProvider.GetAllPurchases();
            _purchases.AddRange(purchasesFromDB);

            PurchasesLoaded?.Invoke();
        }
    }
}
