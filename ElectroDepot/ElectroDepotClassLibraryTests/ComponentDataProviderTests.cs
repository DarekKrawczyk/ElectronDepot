using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class ComponentDataProviderTests : BaseDataProviderTest
    {
        public ComponentDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task GetAll()
        {
            try
            {
                IEnumerable<ComponentDTO> components = await ComponentDP.GetAllComponents();
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
                CategoryDTO category = await CategoryDP.GetCategoryByName("Temperature gauge");

                if (category == null)
                {
                    CreateCategoryDTO gauge = new CreateCategoryDTO(Name: "Temperature gauge", Description: "Measures temperature");
                    bool created = await CategoryDP.CreateCategory(gauge);
                    Assert.True(created);
                    category = await CategoryDP.GetCategoryByName("Temperature gauge");
                    Assert.NotNull(category);
                }

                CreateComponentDTO component = new CreateComponentDTO(CategoryID: category.ID, Name: "LM35", Manufacturer:"Texas Instruments", Description: "Analog temperature gauge");

                bool wasCreated = await ComponentDP.CreateComponent(component);
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
                IEnumerable<ComponentDTO> components = await ComponentDP.GetAllComponents();
                Assert.NotNull(components);
                Assert.True(components.Count() > 0);

                int countBefore = components.Count();

                ComponentDTO last = components.Last();

                await ComponentDP.DeleteComponent(last.ID);

                components = await ComponentDP.GetAllComponents();
                Assert.NotNull(components);
                Assert.True(components.Count() > 0);

                int countAfter = components.Count();

                Assert.True(countBefore == countAfter + 1);
                foreach(ComponentDTO component in components)
                {
                    Console.WriteLine(component.ToString());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task CreateWithCategory()
        {
            try
            {
                CategoryDTO delFirst = await CategoryDP.GetCategoryByName("Silniczek");
                // Delete category
                if(delFirst != null)
                {
                    bool wasDefFirst = await CategoryDP.DeleteCategory(delFirst.ID);
                    Assert.True(wasDefFirst);
                }

                // Create category
                CreateCategoryDTO category = new CreateCategoryDTO(Name: "Silniczek", Description: "Fajnie kreci");
                bool wasCreated = await CategoryDP.CreateCategory(category);
                Assert.True(wasCreated);

                // Find
                CategoryDTO foundCategory = await CategoryDP.GetCategoryByName(category.Name);
                Assert.NotNull(foundCategory);

                // Delete component if exists
                ComponentDTO delCompFirst = await ComponentDP.GetComponentByName("Silniczek");
                if(delCompFirst != null)
                {
                    bool wasdelCompFirst = await ComponentDP.DeleteComponent(delCompFirst);
                    Assert.True(wasdelCompFirst);
                }

                // Create component with category
                CreateComponentDTO component = new CreateComponentDTO(CategoryID: foundCategory.ID, Name: "Silniczek", Manufacturer: "Texus fujara", Description: "Ale kręci");
                bool wasComponentCreated = await ComponentDP.CreateComponent(component);
                Assert.True(wasComponentCreated);

                // Find create component
                ComponentDTO createdComponent = await ComponentDP.GetComponentByName(component.Name);
                Assert.NotNull(createdComponent);

                Console.WriteLine(createdComponent.ToString());
                Console.WriteLine(foundCategory.ToString());

                // Delete component
                bool wasComponentDeleted = await ComponentDP.DeleteComponent(createdComponent.ID);
                Assert.True(wasComponentDeleted);
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
                ComponentDTO foundComponent = await ComponentDP.GetComponentByID(1);
                Assert.NotNull(foundComponent);

                // Update
                ComponentDTO editedCategoryDTO = new ComponentDTO(ID: foundComponent.ID, CategoryID: foundComponent.CategoryID, Name: foundComponent.Name, Manufacturer: foundComponent.Manufacturer, Description: "Edited component");
                bool wasUpdated = await ComponentDP.UpdateComponent(editedCategoryDTO);
                Assert.True(wasUpdated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

