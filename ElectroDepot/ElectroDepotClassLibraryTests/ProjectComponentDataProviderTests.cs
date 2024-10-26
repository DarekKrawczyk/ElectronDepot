using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class ProjectComponentDataProviderTests : BaseDataProviderTest
    {
        public ProjectComponentDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Create()
        {
            try
            {
                // Find Project and Component
                IEnumerable<ProjectDTO> projects = await ProjectDP.GetAllProjects();
                Assert.NotNull(projects);
                ProjectDTO? project = projects.FirstOrDefault();
                Assert.NotNull(project);

                IEnumerable<ComponentDTO> components = await ComponentDP.GetAllComponents();
                Assert.NotNull(components);
                ComponentDTO? component = components.FirstOrDefault();
                Assert.NotNull(component);

                CreateProjectComponentDTO projectComponent = new CreateProjectComponentDTO(ComponentID: component.ID, ProjectID: project.ID, 20);
                bool wasCreated = await ProjectComponentDP.CreateProjectComponent(projectComponent);
                Assert.True(wasCreated);

                Console.WriteLine($"Project component created: {projectComponent.ToString()}");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async Task GetAllFromProject()
        {
            try
            {
                IEnumerable<ProjectDTO> projects = await ProjectDP.GetAllProjects();
                Assert.NotNull(projects);
                ProjectDTO? project = projects.FirstOrDefault();
                Assert.NotNull(project);

                IEnumerable<ProjectComponentDTO> projectComponents = await ProjectComponentDP.GetAllProjectComponentsOfProject(project);
                Assert.NotNull(projectComponents);

                foreach (ProjectComponentDTO projectComponent in projectComponents)
                {
                    Console.WriteLine($"{projectComponent.ToString()}");
                }
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
                IEnumerable<ProjectComponentDTO> projectComponents = await ProjectComponentDP.GetAllProjectComponents();
                Assert.NotNull(projectComponents);

                foreach (ProjectComponentDTO projectComponent in projectComponents)
                {
                    Console.WriteLine($"{projectComponent.ToString()}");
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
                IEnumerable<ProjectComponentDTO> projectComponents = await ProjectComponentDP.GetAllProjectComponents();
                Assert.NotNull(projectComponents);

                ProjectComponentDTO? projectComp = projectComponents.FirstOrDefault();
                Assert.NotNull(projectComp);

                ProjectComponentDTO projectCompUpdated = new ProjectComponentDTO(ID: projectComp.ID, ComponentID: projectComp.ComponentID, ProjectID: projectComp.ProjectID, Quantity: 300); ;
                
                bool wasUpdated = await ProjectComponentDP.UpdateProjectComponent(projectCompUpdated);
                Assert.True(wasUpdated);
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
                IEnumerable<ProjectComponentDTO> projectComponents = await ProjectComponentDP.GetAllProjectComponents();
                Assert.NotNull(projectComponents);
                Assert.NotEmpty(projectComponents);
                ProjectComponentDTO? projectComp = projectComponents.FirstOrDefault();
                Assert.NotNull(projectComp);

                bool wasDeleted = await ProjectComponentDP.DeleteProjectComponent(projectComp);
                Assert.True(wasDeleted);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
