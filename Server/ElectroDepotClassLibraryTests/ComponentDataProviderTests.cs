using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class ComponentDataProviderTests
    {
        private readonly ITestOutputHelper Console;
        private readonly ComponentDataProvider componentDP;
        private readonly CategoryDataProvider categoryDP;

        public ComponentDataProviderTests(ITestOutputHelper output)
        {
            Console = output;
            componentDP = new ComponentDataProvider(Utility.ConnectionURL);
            categoryDP = new CategoryDataProvider(Utility.ConnectionURL);
        }
        [Fact]
        public async Task GetAll()
        {
            try
            {
                IEnumerable<ComponentDTO> components = await componentDP.GetAllComponents();
                Assert.NotNull(components);
                foreach(ComponentDTO component in components)
                {
                    Console.WriteLine($"{component.ToString()}");
                }
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
                // Find category with 'Temperature gauge'
                CategoryDTO category = await categoryDP.GetCategoryByName("Temperature gauge");

                if (category == null)
                {
                    CreateCategoryDTO gauge = new CreateCategoryDTO(Name: "Temperature gauge", Description: "Measures temperature");
                    bool created = await categoryDP.CreateCategory(gauge);
                    Assert.True(created);
                    category = await categoryDP.GetCategoryByName("Temperature gauge");
                    Assert.NotNull(category);
                }

                CreateComponentDTO component = new CreateComponentDTO(CategoryID: category.ID, Name: "LM35", Manufacturer:"Texas Instruments", Description: "Analog temperature gauge");

                bool wasCreated = await componentDP.CreateComponent(component);
                Assert.True(wasCreated);
                Console.WriteLine(component.ToString());
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
                IEnumerable<ComponentDTO> components = await componentDP.GetAllComponents();
                Assert.NotNull(components);
                Assert.True(components.Count() > 0);

                int countBefore = components.Count();

                ComponentDTO last = components.Last();

                await componentDP.DeleteComponent(last);

                components = await componentDP.GetAllComponents();
                Assert.NotNull(components);
                Assert.True(components.Count() > 0);

                int countAfter = components.Count();

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

