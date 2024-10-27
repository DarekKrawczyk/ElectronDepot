using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
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
                CreateSupplierDTO newSupplier = new CreateSupplierDTO(Name: "Botland", Website: @"https://botland.com.pl/");
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
                IEnumerable<SupplierDTO> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                foreach(SupplierDTO supplier in suppliers)
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
                IEnumerable<SupplierDTO> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                SupplierDTO supplier = suppliers.FirstOrDefault();
                Assert.NotNull(supplier);

                string name = supplier.Name;

                SupplierDTO foundSupplier = await SupplierDP.GetSupplierByName(name);
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
                IEnumerable<SupplierDTO> suppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(suppliers);
                Assert.NotEmpty(suppliers);
                SupplierDTO supplier = suppliers.FirstOrDefault();
                Assert.NotNull(supplier);

                int id = supplier.ID;

                SupplierDTO foundSupplier = await SupplierDP.GetSupplierByID(id);
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
                IEnumerable<SupplierDTO> allSuppliers = await SupplierDP.GetAllSuppliers();
                Assert.NotNull(allSuppliers);
                Assert.NotEmpty(allSuppliers);
                SupplierDTO? supplierToBeEdited = allSuppliers.FirstOrDefault();
                Assert.NotNull(supplierToBeEdited);

                Console.WriteLine(supplierToBeEdited.ToString());

                // Update
                SupplierDTO supplier = new SupplierDTO(ID: supplierToBeEdited.ID, Name: "Botlandzik", Website: supplierToBeEdited.Website);
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
