using ElectroDepotClassLibrary.DTOs;
using Newtonsoft.Json.Linq;
using System.Collections;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.TestsOperations
{
    public class OperationTest : BaseDataProviderTest
    {
        private List<CreateUserDTO> UserData = new List<CreateUserDTO>()
        {
            new CreateUserDTO(Username: "Jacek Jaworek", Email: "jacek.jaworek@gmail.com", Password: "FindMeIfYouCan123"),
            new CreateUserDTO(Username: "Anna Kowalska", Email: "anna.kowalska@example.com", Password: "Password123!"),
            new CreateUserDTO(Username: "Piotr Nowak", Email: "piotr.nowak@example.com", Password: "SecurePass456#"),
            new CreateUserDTO(Username: "Maria Wiśniewska", Email: "maria.wisniewska@example.com", Password: "MyPassword789@"),
            new CreateUserDTO(Username: "Tomasz Zieliński", Email: "tomasz.zielinski@example.com", Password: "TopSecret101$")
        };

        private List<CreateCategoryDTO> CategoryData = new List<CreateCategoryDTO>()
        {
            new CreateCategoryDTO(Name: "Czujnik temperatury", Description: "Mierzy temperaturę"),
            new CreateCategoryDTO(Name: "Czujnik wilgotności", Description: "Mierzy wilgotność"),
            new CreateCategoryDTO(Name: "Czujnik ciśnienia", Description: "Mierzy ciśnienie atmosferyczne"),
            new CreateCategoryDTO(Name: "Czujnik światła", Description: "Wykrywa poziom oświetlenia"),
            new CreateCategoryDTO(Name: "Czujnik dymu", Description: "Wykrywa obecność dymu i cząsteczek"),
            new CreateCategoryDTO(Name: "Czujnik ruchu", Description: "Wykrywa ruch w otoczeniu"),
            new CreateCategoryDTO(Name: "Czujnik gazu", Description: "Wykrywa obecność gazów, takich jak CO i metan"),
            new CreateCategoryDTO(Name: "Czujnik ultradźwiękowy", Description: "Wykrywa odległość za pomocą fal ultradźwiękowych"),
            new CreateCategoryDTO(Name: "Czujnik poziomu cieczy", Description: "Monitoruje poziom cieczy w zbiornikach"),
            new CreateCategoryDTO(Name: "Czujnik podczerwieni", Description: "Wykrywa obiekty i temperaturę za pomocą podczerwieni"),
            new CreateCategoryDTO(Name: "Czujnik hałasu", Description: "Mierzy poziom hałasu w decybelach"),
            new CreateCategoryDTO(Name: "Czujnik wibracji", Description: "Wykrywa wibracje i ruch"),
            new CreateCategoryDTO(Name: "Czujnik tętna", Description: "Monitoruje tętno i puls"),
            new CreateCategoryDTO(Name: "Czujnik jakości powietrza", Description: "Monitoruje jakość powietrza i poziom zanieczyszczeń"),
            new CreateCategoryDTO(Name: "Czujnik UV", Description: "Mierzy natężenie promieniowania UV"),
            new CreateCategoryDTO(Name: "Czujnik przyspieszenia", Description: "Mierzy przyspieszenie obiektu"),
            new CreateCategoryDTO(Name: "Czujnik wilgotności gleby", Description: "Monitoruje wilgotność gleby"),
            new CreateCategoryDTO(Name: "Czujnik GPS", Description: "Określa położenie geograficzne")
        };

        private List<string[]> ProjectData = new List<string[]>()
        {
            new string[] { "Podlewaczka", "Podlewa kwiatki w równych interwałach czasowych"},
            new string[] { "Zegar binarny", "Mierzy czas i wyświetla na ekranie"},
            new string[] { "Automatyczny termometr", "Monitoruje temperaturę i wilgotność w pomieszczeniu"},
            new string[] { "Inteligentne lustro", "Wyświetla pogodę, czas i powiadomienia na lustrze"},
            new string[] { "Robot sprzątający", "Automatycznie odkurza podłogi i omija przeszkody"},
            new string[] { "Stacja pogodowa", "Zbiera dane o pogodzie i przesyła je do chmury"},
            new string[] { "Oświetlenie inteligentne", "Dostosowuje jasność i kolor światła do pory dnia"},
            new string[] { "System alarmowy", "Wykrywa ruch i informuje właściciela o zagrożeniu"},
            new string[] { "Asystent głosowy", "Reaguje na polecenia głosowe i wykonuje zadania"},
            new string[] { "Inteligentny zamek", "Otwiera drzwi za pomocą telefonu lub karty NFC"},
            new string[] { "Kamera IP", "Monitoruje teren i przesyła obraz na żywo na telefon"},
            new string[] { "System nawadniania", "Automatycznie podlewa ogród w wybranych godzinach"},
            new string[] { "Analizator powietrza", "Mierzy jakość powietrza i informuje o zanieczyszczeniach"},
            new string[] { "Inteligentna lodówka", "Monitoruje produkty i informuje o kończących się zapasach"},
            new string[] { "Zdalnie sterowane oświetlenie", "Pozwala na zdalne włączanie i wyłączanie światła"},
            new string[] { "System kontroli dostępu", "Umożliwia dostęp do budynku za pomocą kodu lub karty"},
            new string[] { "Ogrzewanie sterowane aplikacją", "Pozwala na regulację temperatury z poziomu telefonu"},
            new string[] { "Monitor zdrowia", "Analizuje tętno, ciśnienie i inne parametry zdrowotne"}
        };

        public OperationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        private async void ClearDatabase()
        {
            try
            {
                ClearUsers();
                ClearCategories();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
            }
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

        [Fact]
        private async void InitializeDatabase()
        {
            try
            {
                //IEnumerable<UserDTO> usersInSystem = await PopulateUsers();
                //PopulateProjects(usersInSystem);
                await PopulateCategoires();

            }
            catch(Exception exception)
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

        private async Task<IEnumerable<UserDTO>> PopulateUsers()
        {
            try
            {
                foreach (CreateUserDTO user in UserData)
                {
                    await UserDP.CreateUser(user);
                }
                IEnumerable<UserDTO> allUsers = await UserDP.GetAllUsers();
                Assert.NotNull(allUsers);
                Assert.True(allUsers.Count() == UserData.Count);

                return allUsers;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
                return new List<UserDTO>();
            }
        }
        private async void PopulateProjects(IEnumerable<UserDTO> users)
        {
            try
            {
                // Utwórz obiekt do losowania
                Random random = new Random();

                foreach (UserDTO user in users)
                {
                    int projectCount = random.Next(1, ProjectData.Count / 2);

                    for (int i = 0; i < projectCount; i++)
                    {
                        // Wybierz losowy projekt
                        string[] project = ProjectData[random.Next(ProjectData.Count)];

                        CreateProjectDTO createProjectDTO = new CreateProjectDTO(UserID: user.ID, Name: project[0], Description: project[1]);

                        await ProjectDP.CreateProject(createProjectDTO);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
                Assert.Fail();
            }
        }
        private async Task PopulateCategoires()
        {
            try
            {
                foreach (CreateCategoryDTO category in CategoryData)
                {
                    await CategoryDP.CreateCategory(category);
                }
                IEnumerable<CategoryDTO> allCategories = await CategoryDP.GetAllCategories();
                Assert.NotNull(allCategories);
                Assert.True(allCategories.Count() == CategoryData.Count);
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
