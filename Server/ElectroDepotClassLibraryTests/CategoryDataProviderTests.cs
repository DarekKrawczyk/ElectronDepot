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
        public async Task GetAll_NotNull()
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
        public async Task Create_False()
        {
            try
            {
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);

                CreateCategoryDTO category = new CreateCategoryDTO(Name: "Wiertara", Description: "Fajnie wierci");

                bool wasCreated = await dbp.CreateCategory(category);

                // False bo zwraca false gdy juz jest taki w bazie
                Assert.False(wasCreated);
                Console.WriteLine($"Category '{category.Name}' was created");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task Delete_True()
        {
            try
            {
                CategoryDataProvider dbp = new CategoryDataProvider(Utility.ConnectionURL);

                IEnumerable<CategoryDTO> categories = await dbp.GetAllCategories();
                Assert.NotNull(categories);
                Assert.True(categories.Count() > 0);

                int countBefore = categories.Count();

                CategoryDTO last = categories.Last();

                await dbp.DaleteCategory(last);

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
    }
}
