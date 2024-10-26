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
        public async Task Delete()
        {
            try
            {
                IEnumerable<CategoryDTO> categories = await CategoryDP.GetAllCategories();
                Assert.NotNull(categories);
                Assert.True(categories.Count() > 0);

                int countBefore = categories.Count();

                CategoryDTO last = categories.Last();

                await CategoryDP.DeleteCategory(last);

                categories = await CategoryDP.GetAllCategories();
                Assert.NotNull(categories);
                Assert.True(categories.Count() > 0);

                int countAfter = categories.Count();

                Assert.True(countBefore == countAfter + 1);
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
                CategoryDTO foundCategory = await CategoryDP.GetCategoryByID(1);
                Assert.NotNull(foundCategory);

                // Update
                CategoryDTO editedCategoryDTO = new CategoryDTO(ID: foundCategory.ID, Name: foundCategory.Name, Description: "Edited category");
                bool wasUpdated = await CategoryDP.UpdateCategory(editedCategoryDTO);
                Assert.True(wasUpdated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
