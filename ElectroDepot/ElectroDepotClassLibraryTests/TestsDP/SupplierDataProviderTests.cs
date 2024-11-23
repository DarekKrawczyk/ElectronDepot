using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Models;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.Tests
{
    public class SupplierDataProviderTests : BaseDataProviderTest
    {
        public SupplierDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public async Task Create()
        {
            try
            {
                Supplier newSupplier = new Supplier(id: -1, name: "Botland", website: @"https://botland.com.pl/", image: new byte[] { });
                bool wasCreated = await SupplierDP.CreateSupplier(newSupplier);
                Assert.True(wasCreated);

                Console.WriteLine(newSupplier.ToString());
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
                IEnumerable<Supplier> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                foreach (Supplier supplier in suppliers)
                {
                    Console.WriteLine(supplier.ToString());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task GetByName()
        {
            try
            {
                IEnumerable<Supplier> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                Supplier supplier = suppliers.FirstOrDefault();
                Assert.NotNull(supplier);

                string name = supplier.Name;

                Supplier foundSupplier = await SupplierDP.GetSupplierByName(name);
                Assert.NotNull(foundSupplier);
                Console.WriteLine(foundSupplier.ToString());
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
                IEnumerable<Supplier> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                Supplier supplier = suppliers.FirstOrDefault();
                Assert.NotNull(supplier);

                int id = supplier.ID;

                Supplier foundSupplier = await SupplierDP.GetSupplierByID(id);
                Assert.NotNull(foundSupplier);
                Console.WriteLine(foundSupplier.ToString());
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
                IEnumerable<Supplier> allSuppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(allSuppliers);
                Assert.NotEmpty(allSuppliers);
                Supplier? supplierToBeEdited = allSuppliers.FirstOrDefault();
                Assert.NotNull(supplierToBeEdited);

                Console.WriteLine(supplierToBeEdited.ToString());

                // Update
                Supplier supplier = new Supplier(id: supplierToBeEdited.ID, name: "Botlandzik", website: supplierToBeEdited.Website, image: supplierToBeEdited.ByteImage);
                bool wasUpdated = await SupplierDP.UpdateSupplier(supplier);
                Assert.True(wasUpdated);
                Console.WriteLine(supplier.ToString());
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
                // Find any supplier
                IEnumerable<Supplier> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                Supplier? lastSupplier = suppliers.LastOrDefault();
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
