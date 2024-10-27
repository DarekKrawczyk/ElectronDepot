using ElectroDepotClassLibrary.DTOs;
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
                IEnumerable<CategoryDTO> categories = await CategoryDP.GetAllCategories();
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
                CreateCategoryDTO category = new CreateCategoryDTO(Name: "Wiertara", Description: "Fajnie wierci");

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
        public async Task CreateUpdateDeleteFind()
        {
            try
            {
                // Create
                CreateCategoryDTO category = new CreateCategoryDTO(Name: "CreateUpdateDeleteFind3_True", Description: "CreateUpdateDeleteFind1_True");
                bool wasCreated = await CategoryDP.CreateCategory(category);
                Assert.True(wasCreated);

                // Find
                CategoryDTO foundCategory = await CategoryDP.GetCategoryByName(category.Name);
                Assert.NotNull(foundCategory);

                // Update
                CategoryDTO editedCategoryDTO = new CategoryDTO(ID: foundCategory.ID, Name: foundCategory.Name, Description: "Edited category");
                bool wasUpdated = await CategoryDP.UpdateCategory(editedCategoryDTO);
                Assert.True(wasUpdated);

                // Delete
                bool wasDeleted = await CategoryDP.DeleteCategory(editedCategoryDTO);
                Assert.True(wasDeleted);

                // Find again
                CategoryDTO foundAgain = await CategoryDP.GetCategoryByName(editedCategoryDTO.Name);
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
        [Fact]
        public async Task DeleteAll()
        {
            try
            {
                // Find
                IEnumerable<CategoryDTO> allCategories = await CategoryDP.GetAllCategories();
                Assert.NotNull(allCategories);

                foreach (CategoryDTO category in allCategories)
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
                IEnumerable<ComponentDTO> allComponents = await ComponentDP.GetAllComponents();
                Assert.True(allComponents.Count() == 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
