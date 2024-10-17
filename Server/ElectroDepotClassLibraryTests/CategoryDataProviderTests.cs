using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Endpoints;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class CategoryDataProviderTests
    {
        private readonly ITestOutputHelper Console;

        public CategoryDataProviderTests(ITestOutputHelper output)
        {
            Console = output;
        }
        [Fact]
        public async Task GetAll()
        {
            try
            {
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);
                IEnumerable<CategoryDTO> categories = await dbp.GetAllCategories();
                Assert.NotNull(categories);
                Console.WriteLine($"Returned '{categories.Count()}' records");   
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
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);

                CreateCategoryDTO category = new CreateCategoryDTO(Name: "Wiertara", Description: "Fajnie wierci");

                bool wasCreated = await dbp.CreateCategory(category);

                Assert.True(wasCreated);
                Console.WriteLine($"Category '{category.Name}' was created");
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
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);

                IEnumerable<CategoryDTO> categories = await dbp.GetAllCategories();
                Assert.NotNull(categories);
                Assert.True(categories.Count() > 0);

                int countBefore = categories.Count();

                CategoryDTO last = categories.Last();

                await dbp.DeleteCategory(last);

                categories = await dbp.GetAllCategories();
                Assert.NotNull(categories);
                Assert.True(categories.Count() > 0);

                int countAfter = categories.Count();

                Assert.True(countBefore == countAfter+1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task CreateUpdateDeleteFind()
        {
            try
            {
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);

                // Create
                CreateCategoryDTO category = new CreateCategoryDTO(Name: "CreateUpdateDeleteFind3_True", Description: "CreateUpdateDeleteFind1_True");
                bool wasCreated = await dbp.CreateCategory(category);
                Assert.True(wasCreated);

                // Find
                CategoryDTO foundCategory = await dbp.GetCategoryByName(category.Name);
                Assert.NotNull(foundCategory);

                // Update
                CategoryDTO editedCategoryDTO = new CategoryDTO(ID: foundCategory.ID, Name: foundCategory.Name, Description: "Edited category");
                bool wasUpdated = await dbp.UpdateCategory(editedCategoryDTO);
                Assert.True(wasUpdated);

                // Delete
                bool wasDeleted = await dbp.DeleteCategory(editedCategoryDTO);
                Assert.True(wasDeleted);

                // Find again
                CategoryDTO foundAgain = await dbp.GetCategoryByName(editedCategoryDTO.Name);
                Assert.Null(foundAgain);

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
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);

                // Find
                CategoryDTO foundCategory = await dbp.GetCategoryByID(1);
                Assert.NotNull(foundCategory);

                // Update
                CategoryDTO editedCategoryDTO = new CategoryDTO(ID: foundCategory.ID, Name: foundCategory.Name, Description: "Edited category");
                bool wasUpdated = await dbp.UpdateCategory(editedCategoryDTO);
                Assert.True(wasUpdated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
