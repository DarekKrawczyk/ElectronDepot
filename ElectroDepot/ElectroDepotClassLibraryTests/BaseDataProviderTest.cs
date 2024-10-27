using ElectroDepotClassLibrary.DataProviders;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class BaseDataProviderTest
    {
        public ITestOutputHelper Console { get; }
        public ComponentDataProvider ComponentDP { get; }
        public CategoryDataProvider CategoryDP { get; }
        public UserDataProvider UserDP { get; }
        public OwnsComponentDataProvider OwnsComponentDP{ get; }
        public ProjectDataProvider ProjectDP { get; }
        public ProjectComponentDataProvider ProjectComponentDP { get; }
        public SupplierDataProvider SupplierDP { get; }
        public PurchaseDataProvider PurchaseDP { get; }
        public PurchaseItemDataProvider PurchaseItemDP { get; }

        public BaseDataProviderTest(ITestOutputHelper output)
        {
            Console = output;
            ComponentDP = new ComponentDataProvider(Utility.ConnectionURL);
            CategoryDP = new CategoryDataProvider(Utility.ConnectionURL);
            UserDP = new UserDataProvider(Utility.ConnectionURL);
            OwnsComponentDP = new OwnsComponentDataProvider(Utility.ConnectionURL);
            ProjectDP = new ProjectDataProvider(Utility.ConnectionURL);
            ProjectComponentDP = new ProjectComponentDataProvider(Utility.ConnectionURL);
            SupplierDP = new SupplierDataProvider(Utility.ConnectionURL);
            PurchaseDP = new PurchaseDataProvider(Utility.ConnectionURL);
            PurchaseItemDP = new PurchaseItemDataProvider(Utility.ConnectionURL);
        }
    }
}
