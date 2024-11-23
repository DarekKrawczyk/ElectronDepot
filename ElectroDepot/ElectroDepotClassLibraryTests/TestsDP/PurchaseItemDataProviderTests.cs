using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Models;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.Tests
{
    public class PurchaseItemDataProviderTests : BaseDataProviderTest
    {
        public PurchaseItemDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public async Task Create()
        {
            try
            {
                // Find 'Purchase' and 'Component'
                IEnumerable<Purchase> purchases = await PurchaseDP.GetAllPurchases();
                Assert.NotNull(purchases);
                Assert.NotEmpty(purchases);
                Purchase? purchase = purchases.FirstOrDefault();
                Assert.NotNull(purchase);

                IEnumerable<Component> componenets = await ComponentDP.GetAllComponents();
                Assert.NotNull(componenets);
                Assert.NotEmpty(componenets);
                Component? component = componenets.FirstOrDefault();
                Assert.NotNull(component);

                CreatePurchaseItemDTO purchaseItem = new CreatePurchaseItemDTO(PurchaseID: purchase.ID, ComponentID: component.ID, Quantity: 30, PricePerUnit: 19.99);
                bool wasCreated = await PurchaseItemDP.CreatePurchaseItem(purchaseItem);
                Assert.True(wasCreated);

                Console.WriteLine(purchaseItem.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task GetByID()
        {
            try
            {
                IEnumerable<PurchaseItemDTO> purchases = await PurchaseItemDP.GetAllPurchaseItems();
                Assert.NotNull(purchases);
                Assert.NotEmpty(purchases);
                PurchaseItemDTO? purchase = purchases.FirstOrDefault();
                Assert.NotNull(purchase);

                int ID = purchase.ID;
                purchase = null;

                PurchaseItemDTO purchaseItem = await PurchaseItemDP.GetPurchaseItemByID(ID);
                Assert.NotNull(purchaseItem);
                Console.WriteLine(purchaseItem.ToString());
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
                IEnumerable<PurchaseItemDTO> purchaseItems = await PurchaseItemDP.GetAllPurchaseItems();
                Assert.NotNull(purchaseItems);
                foreach (PurchaseItemDTO purchaseItem in purchaseItems)
                {
                    Console.WriteLine(purchaseItem.ToString());
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
                IEnumerable<PurchaseItemDTO> allPurchases = await PurchaseItemDP.GetAllPurchaseItems();
                Assert.NotNull(allPurchases);
                Assert.NotEmpty(allPurchases);
                PurchaseItemDTO? purchaseToBeEdited = allPurchases.FirstOrDefault();
                Assert.NotNull(purchaseToBeEdited);

                Console.WriteLine(purchaseToBeEdited.ToString());

                // Update
                PurchaseItemDTO purchase = new PurchaseItemDTO(ID: purchaseToBeEdited.ID, PurchaseID: purchaseToBeEdited.PurchaseID, ComponentID: purchaseToBeEdited.ComponentID, Quantity: 2000, PricePerUnit: purchaseToBeEdited.PricePerUnit);
                bool wasUpdated = await PurchaseItemDP.UpdatePurchaseItem(purchase);
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
                IEnumerable<PurchaseItemDTO> allPurchaseItems = await PurchaseItemDP.GetAllPurchaseItems();
                Assert.NotNull(allPurchaseItems);
                Assert.NotEmpty(allPurchaseItems);

                foreach (PurchaseItemDTO singleItem in allPurchaseItems)
                {
                    Console.WriteLine(singleItem.ToString());
                }

                PurchaseItemDTO? firstItem = allPurchaseItems.FirstOrDefault();
                bool wasDeleted = await PurchaseItemDP.DeletePuchaseItem(firstItem);
                Assert.True(wasDeleted);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
