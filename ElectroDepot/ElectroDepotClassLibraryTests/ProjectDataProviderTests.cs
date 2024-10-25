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
                bool wasCreate = await ProjectDP.CreateUser(project);
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
                IEnumerable<UserDTO> users = await UserDP.GetAllUsers();
                Assert.NotNull(users);
                foreach (UserDTO user in users)
                {
                    Console.WriteLine($"{user.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async Task GetByUsername()
        {
            try
            {
                UserDTO? user = await UserDP.GetUserByUsername("Darek");
                Assert.NotNull(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
