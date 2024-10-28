using ElectroDepotClassLibrary.DTOs;
using Newtonsoft.Json.Linq;
using System.Collections;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.TestsOperations
{
    public class OperationTest : BaseDataProviderTest
    {
        public OperationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        private async void DisplayDatabase()
        {
            try
            {
                //await DisplayUsers();
                //await DisplayProjects();
                await DisplayCategories();
                //await DisplayProjectsOfUsers();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
            }
        }

        private async void ClearUsers()
        {
            try
            {
                // Clear 'Users'
                IEnumerable<UserDTO> allUsers = await UserDP.GetAllUsers();
                Assert.NotNull(allUsers);
                foreach(UserDTO user in allUsers)
                {
                    await UserDP.DeleteUser(user);
                }
                allUsers = await UserDP.GetAllUsers();
                Assert.NotNull(allUsers);
                Assert.Empty(allUsers);
                Console.WriteLine("'Users' count = 0");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }

        private async void ClearCategories()
        {
            try
            {
                IEnumerable<CategoryDTO> allCategories = await CategoryDP.GetAllCategories();
                Assert.NotNull(allCategories);
                foreach (CategoryDTO category in allCategories)
                {
                    await CategoryDP.DeleteCategory(category);
                }
                allCategories = await CategoryDP.GetAllCategories();
                Assert.NotNull(allCategories);
                Assert.Empty(allCategories);
                Console.WriteLine("'Categories' count = 0");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }
        private async Task DisplayUsers()
        {
            try
            {
                IEnumerable<UserDTO> allUsers = await UserDP.GetAllUsers();
                Console.WriteLine("'Users' table");
                foreach (UserDTO user in allUsers)
                {
                    Console.WriteLine(user.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }

        private async Task DisplayCategories()
        {
            try
            {
                IEnumerable<CategoryDTO> allCategories = await CategoryDP.GetAllCategories();
                Console.WriteLine("'Categories' table");
                foreach (CategoryDTO category in allCategories)
                {
                    Console.WriteLine(category.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }

        private async Task DisplayProjects()
        {
            try
            {
                IEnumerable<ProjectDTO> allProjects = await ProjectDP.GetAllProjects();
                Console.WriteLine("'Projects' table");
                foreach (ProjectDTO project in allProjects)
                {
                    Console.WriteLine(project.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }

        private async Task DisplayProjectsOfUsers()
        {
            try
            {
                IEnumerable<UserDTO> allUsers = await UserDP.GetAllUsers();
                if (allUsers.Count() == 0)
                {
                    Console.WriteLine($"   No users");
                }
                else
                {
                    foreach (UserDTO user in allUsers)
                    {
                        IEnumerable<ProjectDTO> allProjects = await ProjectDP.GetAllProjectOfUser(user);
                        Console.WriteLine($"{user.Username}'s projects");
                        if(allProjects.Count() == 0)
                        {
                            Console.WriteLine($"   No projects");
                        }
                        else
                        {
                            foreach (ProjectDTO project in allProjects)
                            {
                                Console.WriteLine("   " + project.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }
    }
}
