using ElectroDepotClassLibrary.DTOs;
using System.Linq;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.TestsOperations
{
    public class TypicalSelectAPICallsTests : BaseDataProviderTest
    {

        public TypicalSelectAPICallsTests(ITestOutputHelper output) : base(output)
        {
        }
        #region Users
        [Fact]
        private async Task Get_all_users()
        {
            try
            {
                string[][] users = new string[][]
                {
                    new string[] { "jacek.jaworek", "jacek.jaworek@gmail.com" },
                    new string[] { "agnieszka.nakowicz", "agnieszka.nakowicz@gmail.com" },
                    new string[] { "hanna.kozłowska", "hanna.kozłowska@gmail.com" },
                    new string[] { "piotr.wisniewski", "piotr.wisniewski@gmail.com" },
                    new string[] { "jarosław.paduch", "jarosław.paduch@gmail.com" },
                    new string[] { "andrzej.kowalski", "andrzej.kowalski@gmail.com" },
                    new string[] { "oleg.ontemijczuk", "oleg.ontemijczuk@gmail.com" },
                    new string[] { "ewa.maj", "ewa.maj@gmail.com" },
                    new string[] { "grzegorz.baron", "grzegorz.baron@gmail.com" },
                    new string[] { "joanna.pawlowska", "joanna.pawlowska@gmail.com" }
                };
                IEnumerable<UserDTO> allUsersFromDB = await UserDP.GetAllUsers();

                foreach (UserDTO user in allUsersFromDB)
                {
                    Console.WriteLine(user.ToString());
                    string[] dbUserData = new string[] {user.Username, user.Email };
                    if (!users.Any(x=> x[0] == dbUserData[0] && x[1] == dbUserData[1]))
                    {
                        Assert.Fail($"User '{user.Username}' not found!");
                    }
                }
            }
            catch(Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task User_modify_password()
        {
            try
            {
                UserDTO user = await UserDP.GetUserByUsername("jacek.jaworek");
                Assert.NotNull(user);

                UpdateUserDTO userModified = new UpdateUserDTO(user.Username, user.Email, "NewPasswordUpdated123");
                bool wasUpdated = await UserDP.UpdateUser(user.ID, userModified);
                Assert.True(wasUpdated);

                UpdateUserDTO userReModified = new UpdateUserDTO(user.Username, user.Email, "FindMeIfYouCan123");
                bool wasReUpdated = await UserDP.UpdateUser(user.ID, userReModified);
                Assert.True(wasUpdated);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_all_components_from_user()
        {
            try
            {
                int[] CompsIDsOfJacekJaworek = new int[] { 77, 2, 5, 38, 82, 67, 9 };

                UserDTO user = await UserDP.GetUserByUsername("jacek.jaworek");
                IEnumerable<ComponentDTO> componentsOfUser = await ComponentDP.GetAllUserComponent(user.ID);
                foreach(ComponentDTO component in componentsOfUser)
                {
                    // Bias is Used to match with ids from TestingData.md
                    Console.WriteLine($"UserID: '{user.ID - Utility.UserIDBias}', ComponentID: '{component.ID - Utility.ComponentIDBias}'");
                }
                int[] dbIDs = componentsOfUser.Select(x => x.ID - Utility.ComponentIDBias).ToArray();

                Assert.True(CompsIDsOfJacekJaworek.OrderBy(x => x).SequenceEqual(dbIDs.OrderBy(x => x)));
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_all_projects_from_user()
        {
            try
            {
                int[] ProjectsIDsOfJacekJaworek = new int[] { 0, 4 };

                UserDTO user = await UserDP.GetUserByUsername("jacek.jaworek");
                IEnumerable<ProjectDTO> projectsOfUser = await ProjectDP.GetAllProjectOfUser(user);
                foreach (ProjectDTO project in projectsOfUser)
                {
                    // Bias is used to match with ids from TestingData.md
                    Console.WriteLine($"UserID: '{user.ID - Utility.UserIDBias}', Project: '{project.Name}'");
                }
                int[] dbIDs = projectsOfUser.Select(x => x.ID - Utility.ProjectIDBias).ToArray();

                Assert.True(ProjectsIDsOfJacekJaworek.OrderBy(x => x).SequenceEqual(dbIDs.OrderBy(x => x)));
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_component_amount_from_user()
        {
            try
            {
                int[][] OwnedComponentCountOfJacekJaworek = new int[][] 
                { 
                    new int[] { 77, 1 },
                    new int[] { 2, 1 },
                    new int[] { 5, 2 },
                    new int[] { 38, 1 },
                    new int[] { 82, 2 },
                    new int[] { 67, 2 },
                    new int[] { 9, 2 },
                };

                UserDTO user = await UserDP.GetUserByUsername("jacek.jaworek");
                Assert.NotNull(user);

                IEnumerable<OwnsComponentDTO> OwnedComponentsOfUser = await OwnsComponentDP.GetAllOwnsComponentsFromUser(user);
                Assert.NotNull(OwnedComponentsOfUser);

                foreach (OwnsComponentDTO ownedComponent in OwnedComponentsOfUser)
                {
                    // Bias is used to match with ids from TestingData.md
                    Console.WriteLine($"UserID: '{user.ID - Utility.UserIDBias}', ComponentID: '{ownedComponent.ComponentID - Utility.ComponentIDBias}', Quantity: '{ownedComponent.Quantity}'");

                    int[] dbIDs = new int[] { ownedComponent.ComponentID - Utility.ComponentIDBias, ownedComponent.Quantity };

                    Assert.True(OwnedComponentCountOfJacekJaworek.Any(y => y.OrderBy(x => x).SequenceEqual(dbIDs.OrderBy(x => x))));
                }

                IEnumerable<ComponentDTO> ComponentsOfUser = await ComponentDP.GetAllUserComponent(user.ID);
                Assert.NotNull(ComponentsOfUser);

                ComponentDTO FirstComponent = ComponentsOfUser.FirstOrDefault();
                Assert.NotNull(FirstComponent);

                OwnsComponentDTO componentOfComponentAndUser = await OwnsComponentDP.GetOwnComponentsFromUser(user, FirstComponent);
                Assert.NotNull(componentOfComponentAndUser);

                Console.WriteLine($"Found: Owner:'{user.ID - Utility.UserIDBias}', ComponentID:'{componentOfComponentAndUser.ComponentID - Utility.ComponentIDBias}', Quantity:'{componentOfComponentAndUser.Quantity}'");

            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }
        #endregion
    }
}
