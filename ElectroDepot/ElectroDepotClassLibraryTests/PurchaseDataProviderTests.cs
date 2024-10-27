using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class PurchaseDataProviderTests : BaseDataProviderTest
    {
        public PurchaseDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public async Task Create()
        {
            try
            {
                // Find 'User'
                IEnumerable<UserDTO> users = await UserDP.GetAllUsers();
                Assert.NotNull(users);
                Assert.NotEmpty(users);
                UserDTO? user = users.FirstOrDefault();
                Assert.NotNull(user);

                // Find 'Supplier'
                IEnumerable<SupplierDTO> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                SupplierDTO? supplier = suppliers.FirstOrDefault();
                Assert.NotNull(supplier);

                // Create new 'Purchase'
                CreatePurchaseDTO newPurchase = new CreatePurchaseDTO(UserID: user.ID, SupplierID: supplier.ID, PurchaseDate: DateTime.Now, TotalPrice: 0);
                bool wasCreated = await PurchaseDP.CreatePurchase(newPurchase);
                Assert.True(wasCreated);

                Console.WriteLine(newPurchase.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task GetAll()
        {
            try
            {
                IEnumerable<PurchaseDTO> purchases = await PurchaseDP.GetAllPurchases();
                Assert.NotNull(purchases);
                foreach (PurchaseDTO purchase in purchases)
                {
                    Console.WriteLine(purchase.ToString());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task GetAllByUserID()
        {
            try
            {
                // Find 'User'
                IEnumerable<UserDTO> users = await UserDP.GetAllUsers();
                Assert.NotNull(users);
                Assert.NotEmpty(users);
                UserDTO? user = users.FirstOrDefault();
                Assert.NotNull(user);

                IEnumerable<PurchaseDTO> purchaeses = await PurchaseDP.GetAllPurchasesFromUser(user);
                Assert.NotNull(purchaeses);

                foreach(PurchaseDTO purchase in purchaeses)
                {
                    Console.WriteLine(purchase.ToString());
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task GetAllBySupplierID()
        {
            try
            {
                // Find 'Supplier'
                IEnumerable<SupplierDTO> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                SupplierDTO? supplier = suppliers.FirstOrDefault();
                Assert.NotNull(supplier);

                IEnumerable<PurchaseDTO> purchaeses = await PurchaseDP.GetAllPurchasesFromSupplier(supplier);
                Assert.NotNull(purchaeses);

                foreach (PurchaseDTO purchase in purchaeses)
                {
                    Console.WriteLine(purchase.ToString());
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task Update()
        {
            try
            {
                // Find
                IEnumerable<PurchaseDTO> allPurchases = await PurchaseDP.GetAllPurchases();
                Assert.NotNull(allPurchases);
                Assert.NotEmpty(allPurchases);
                PurchaseDTO? purchaseToBeEdited = allPurchases.FirstOrDefault();
                Assert.NotNull(purchaseToBeEdited);

                Console.WriteLine(purchaseToBeEdited.ToString());

                // Update
                PurchaseDTO purchase = new PurchaseDTO(ID: purchaseToBeEdited.ID, UserID:purchaseToBeEdited.UserID, SupplierID: purchaseToBeEdited.SupplierID, PurchaseDate: purchaseToBeEdited.PurchaseDate, TotalPrice: 201);
                bool wasUpdated = await PurchaseDP.UpdatePurchase(purchase);
                Assert.True(wasUpdated);
                Console.WriteLine(purchase.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task Delete()
        {
            try
            {
                // Find any purchase
                IEnumerable<SupplierDTO> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                SupplierDTO? lastSupplier = suppliers.LastOrDefault();
                Assert.NotNull(lastSupplier);

                // Delete
                bool wasDeleted = await SupplierDP.DeleteSupplier(lastSupplier);
                Assert.True(wasDeleted);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
