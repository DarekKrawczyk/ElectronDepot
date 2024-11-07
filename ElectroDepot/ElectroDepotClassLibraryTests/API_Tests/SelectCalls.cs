using ElectroDepotClassLibrary.DTOs;
using System.Linq;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.TestsOperations
{
    public class SelectCalls : BaseDataProviderTest
    {

        public SelectCalls(ITestOutputHelper output) : base(output)
        {
        }
        #region Users
        [Fact]
        private async Task Get_All_Users()
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
        public async Task Get_All_Components_From_User()
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
        public async Task Get_All_Projects_From_User()
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
        public async Task Get_Component_Amount_From_User()
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

        [Fact]
        public async Task Get_All_Components_From_Project()
        {
            try
            {
                int[] ComponentsIDsFromProject0 = new int[] { 77, 2, 5, 38 };

                int projectID = Utility.ProjectIDBias;

                ProjectDTO project = await ProjectDP.GetProjectByID(projectID); 
                Assert.NotNull(project);

                IEnumerable<ComponentDTO> ComponentsOfProject = await ProjectDP.GetAllComponentsFromProject(project);
                Assert.NotNull(ComponentsOfProject);
                Assert.NotEmpty(ComponentsOfProject);

                int[] ids = ComponentsOfProject.Select(x => Math.Abs(Utility.ComponentIDBias - x.ID)).ToArray();

                bool isSame = ComponentsIDsFromProject0.SequenceEqual(ids);
                Assert.True(isSame);

                foreach (ComponentDTO ownedComponent in ComponentsOfProject)
                {
                    Console.WriteLine(ownedComponent.ToString());
                }
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_All_Purchases_From_User()
        {
            try
            {
                // DATA DEF
                string username = "agnieszka.nakowicz";
                int[] purchaseIDS = new int[] { 1, 2 };
                //

                UserDTO user = await UserDP.GetUserByUsername(username);
                Assert.NotNull(user);

                IEnumerable<PurchaseDTO> purchases = await PurchaseDP.GetAllPurchasesFromUser(user);
                Assert.NotNull(purchases);
                Assert.NotEmpty(purchases);

                int[] purIDS = purchases.Select(x=> Math.Abs(Utility.PurchaseIDBias - x.ID)).ToArray();
                bool isSame = purIDS.SequenceEqual(purchaseIDS);
                Assert.True(isSame);

                foreach (PurchaseDTO purchase in purchases)
                {
                    Console.WriteLine(purchase.ToString());
                }
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_Project_Price()
        {
            try
            {
                // DATA DEF
                int projectID = Utility.ProjectIDBias;
                //

                ProjectDTO project = await ProjectDP.GetProjectByID(projectID);
                Assert.NotNull(project);

                double projectPrice = await ProjectDP.GetProjectPrice(project);
                Assert.True(projectPrice != -1.0);
                Assert.True(projectPrice == 27.5);

                Console.WriteLine($"Price for '{project.Name}' project is '{projectPrice}'[pln]");
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_All_Components_From_Purchase()
        {
            try
            {
                // Data definition
                int projectID = Utility.ProjectIDBias;

                ProjectDTO project = await ProjectDP.GetProjectByID(projectID);
                Assert.NotNull(project);

                double projectPrice = await ProjectDP.GetProjectPrice(project);
                Assert.True(projectPrice != -1.0);
                Assert.True(projectPrice == 27.5);

                Console.WriteLine($"Price for '{project.Name}' project is '{projectPrice}'[pln]");
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_All_PurchaseItems_From_Purchase()
        {
            try
            {
                // Data definition
                int purchaseID = Utility.PurchaseIDBias;
                int[] IDsArray = new int[] { 77, 2, 5, 38, 82, 67, 9 };
                int[] quantities = new int[] { 1, 1, 2, 1, 2, 2, 2 };

                PurchaseDTO purchase = await PurchaseDP.GetPurchaseByID(purchaseID);
                Assert.NotNull(purchase);

                IEnumerable<PurchaseItemDTO> purchaseItems = await PurchaseItemDP.GetAllPurchaseItemsFromPurchase(purchase);
                Assert.NotNull(purchaseItems);
                Assert.NotEmpty(purchaseItems);

                int[] idsFromDB = purchaseItems.Select(x => Math.Abs(Utility.ComponentIDBias - x.ComponentID)).ToArray();
                int[] quantitiesFromDB = purchaseItems.Select(x => x.Quantity).ToArray();

                bool areIDsOk = idsFromDB.SequenceEqual(IDsArray);
                bool areQuantitiesOk = quantitiesFromDB.SequenceEqual(quantities);

                Assert.True(areIDsOk);
                Assert.True(areQuantitiesOk);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_Free_To_Use_OwnsComponents()
        {
            try
            {
                // Data definition
                int userID = Utility.UserIDBias;
                
                UserDTO user = await UserDP.GetUserByID(userID);
                Assert.NotNull(user);

                IEnumerable<OwnsComponentDTO> freeToUseComponents = await OwnsComponentDP.GetAllFreeToUseComponentsFromUser(user);
                Assert.NotNull(freeToUseComponents);

                //int[] idsFromDB = purchaseItems.Select(x => Math.Abs(Utility.ComponentIDBias - x.ComponentID)).ToArray();
                //int[] quantitiesFromDB = purchaseItems.Select(x => x.Quantity).ToArray();

                //bool areIDsOk = idsFromDB.SequenceEqual(IDsArray);
                //bool areQuantitiesOk = quantitiesFromDB.SequenceEqual(quantities);

                //Assert.True(areIDsOk);
                //Assert.True(areQuantitiesOk);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [Fact]
        public async Task Get_All_OwnsComponents_From_User()
        {
            try
            {
                // Data definition
                int userID = Utility.UserIDBias;
                int[] IDsArray = new int[] { 77, 2, 5, 38, 82, 67, 9 };
                int[] quantities = new int[] { 1, 1, 2, 1, 2, 2, 2 };
                
                UserDTO user = await UserDP.GetUserByID(userID);
                Assert.NotNull(user);

                IEnumerable<OwnsComponentDTO> ownedComponents = await OwnsComponentDP.GetAllOwnsComponentsFromUser(user);
                Assert.NotNull(ownedComponents);
                Assert.NotEmpty(ownedComponents);

                int[] idsFromDB = ownedComponents.Select(x => Math.Abs(Utility.ComponentIDBias - x.ComponentID)).ToArray();
                int[] quantitiesFromDB = ownedComponents.Select(x => x.Quantity).ToArray();

                bool areIDsOk = idsFromDB.SequenceEqual(IDsArray);
                bool areQuantitiesOk = quantitiesFromDB.SequenceEqual(quantities);

                Assert.True(areIDsOk);
                Assert.True(areQuantitiesOk);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }
        #endregion
    }
}
