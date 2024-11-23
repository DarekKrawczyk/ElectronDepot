using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Models;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.Tests
{
    public class CategoryDataProviderTests : BaseDataProviderTest
    {
        public CategoryDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task GetAll()
        {
            try
            {
                IEnumerable<Category> categories = await CategoryDP.GetAllCategories();
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
                Category category = new Category(id: 0, name: "Wiertara", description: "Fajnie wierci", image: new byte[] { });

                bool wasCreated = await CategoryDP.CreateCategory(category);

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
                IEnumerable<Category> categories = await CategoryDP.GetAllCategories();
                Assert.NotNull(categories);
                Assert.True(categories.Count() > 0);

                int countBefore = categories.Count();

                Category last = categories.Last();

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
        public async Task CreateUpdateDeleteFind()
        {
            try
            {
                // Create
                Category category = new Category(id: 0, name: "CreateUpdateDeleteFind3_True", description: "CreateUpdateDeleteFind1_True", image: new byte[] { });
                bool wasCreated = await CategoryDP.CreateCategory(category);
                Assert.True(wasCreated);

                // Find
                Category foundCategory = await CategoryDP.GetCategoryByName(category.Name);
                Assert.NotNull(foundCategory);

                // Update
                Category editedCategoryDTO = new Category(id: foundCategory.ID, name: foundCategory.Name, description: "Edited category", image: new byte[] { });
                bool wasUpdated = await CategoryDP.UpdateCategory(editedCategoryDTO);
                Assert.True(wasUpdated);

                // Delete
                bool wasDeleted = await CategoryDP.DeleteCategory(editedCategoryDTO);
                Assert.True(wasDeleted);

                // Find again
                Category foundAgain = await CategoryDP.GetCategoryByName(editedCategoryDTO.Name);
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
                // Find
                Category foundCategory = await CategoryDP.GetCategoryByID(1);
                Assert.NotNull(foundCategory);

                // Update
                Category editedCategoryDTO = new Category(id: foundCategory.ID, name: foundCategory.Name, description: "Edited category", image: new byte[] { });
                bool wasUpdated = await CategoryDP.UpdateCategory(editedCategoryDTO);
                Assert.True(wasUpdated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task DeleteAll()
        {
            try
            {
                // Find
                IEnumerable<Category> allCategories = await CategoryDP.GetAllCategories();
                Assert.NotNull(allCategories);

                foreach (Category category in allCategories)
                {
                    Console.WriteLine(category.ToString());
                }

                // Delete
                int[] IDs = allCategories.Select(x => x.ID).ToArray();
                foreach (int id in IDs)
                {
                    bool wasDeleted = await CategoryDP.DeleteCategory(id);
                    Assert.True(wasDeleted);
                }

                // Now components table should be empty
                IEnumerable<Component> allComponents = await ComponentDP.GetAllComponents();
                Assert.True(allComponents.Count() == 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
