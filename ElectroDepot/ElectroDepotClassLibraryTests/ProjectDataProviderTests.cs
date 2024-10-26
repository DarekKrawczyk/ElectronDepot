using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class ProjectDataProviderTests : BaseDataProviderTest
    {
        public ProjectDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public async Task Create()
        {
            try
            {
                // Find any User
                IEnumerable<UserDTO> users = await UserDP.GetAllUsers();
                UserDTO? user = users.FirstOrDefault();

                Assert.NotNull(user);

                CreateProjectDTO project = new CreateProjectDTO(UserID: user.ID, Name: "Stacja meterologiczna", Description: "Na SMIW");
                bool wasCreate = await ProjectDP.CreateProject(project);
                Assert.True(wasCreate);

                Console.WriteLine($"Project created: {project.ToString()}");
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
                IEnumerable<ProjectDTO> projects = await ProjectDP.GetAllProjects();
                Assert.NotNull(projects);
                foreach (ProjectDTO project in projects)
                {
                    Console.WriteLine($"{project.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async Task GetAllFromUser()
        {
            try
            {
                // Find any User
                IEnumerable<UserDTO> users = await UserDP.GetAllUsers();
                UserDTO? user = users.FirstOrDefault();
                Assert.NotNull(user);

                IEnumerable<ProjectDTO> projects = await ProjectDP.GetAllProjectOfUser(user);
                Assert.NotNull(projects);
                foreach (ProjectDTO project in projects)
                {
                    Console.WriteLine($"{project.ToString()}");
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
                // Find any User
                IEnumerable<UserDTO> users = await UserDP.GetAllUsers();
                UserDTO? user = users.FirstOrDefault();
                Assert.NotNull(user);

                IEnumerable<ProjectDTO> projects = await ProjectDP.GetAllProjectOfUser(user);
                Assert.NotNull(projects);
                Console.WriteLine("Before update");
                foreach (ProjectDTO project in projects)
                {
                    Console.WriteLine($"{project.ToString()}");
                }

                ProjectDTO projectUpdated = projects.FirstOrDefault();
                ProjectDTO projectToSend = new ProjectDTO(ID: projectUpdated.ID, UserID: projectUpdated.UserID, Name: "Fajna stacja pogodowa", Description: projectUpdated.Description, CreatedAt: projectUpdated.CreatedAt);

                bool wasChanged = await ProjectDP.UpdateProject(projectToSend);
                Assert.True(wasChanged);

                IEnumerable<ProjectDTO> updatedProjects = await ProjectDP.GetAllProjectOfUser(user);
                Assert.NotNull(updatedProjects);
                Console.WriteLine("\nAfter update");
                foreach (ProjectDTO project in updatedProjects)
                {
                    Console.WriteLine($"{project.ToString()}");
                }
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
                // Find any Project
                IEnumerable<ProjectDTO> projects = await ProjectDP.GetAllProjects();
                Assert.NotNull(projects);

                ProjectDTO? projectToDelete = projects.FirstOrDefault();
                Assert.NotNull(projectToDelete);

                bool wasDeleted = await ProjectDP.DeleteProject(projectToDelete);
                Assert.True(wasDeleted);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
