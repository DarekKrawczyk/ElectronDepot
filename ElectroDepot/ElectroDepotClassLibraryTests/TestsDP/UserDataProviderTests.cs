using ElectroDepotClassLibrary.DTOs;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.Tests
{
    public class UserDataProviderTests : BaseDataProviderTest
    {
        public UserDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Create()
        {
            try
            {
                CreateUserDTO user = new CreateUserDTO(Username: "Darek", Email: "Darek@gmail.com", Password: "Pieczarka");

                bool wasCreated = await UserDP.CreateUser(user);
                Assert.True(wasCreated);

                Console.WriteLine($"User created: {user.ToString()}");
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

        [Fact]
        public async Task GetByID()
        {
            try
            {
                IEnumerable<UserDTO> allUsers = await UserDP.GetAllUsers();
                Assert.NotNull(allUsers);
                Assert.NotEmpty(allUsers);

                foreach (UserDTO singleuser in allUsers)
                {
                    Console.WriteLine(singleuser.ToString());
                }

                int ID = allUsers.FirstOrDefault().ID;

                UserDTO? user = await UserDP.GetUserByID(ID);
                Assert.NotNull(user);
                Console.WriteLine(user.ToString());
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
                IEnumerable<UserDTO> allUsers = await UserDP.GetAllUsers();
                Assert.NotNull(allUsers);
                Assert.NotEmpty(allUsers);

                foreach (UserDTO singleuser in allUsers)
                {
                    Console.WriteLine(singleuser.ToString());
                }

                UserDTO firstUser = allUsers.FirstOrDefault();

                bool wasDeleted = await UserDP.DeleteUser(firstUser);
                Assert.True(wasDeleted);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
