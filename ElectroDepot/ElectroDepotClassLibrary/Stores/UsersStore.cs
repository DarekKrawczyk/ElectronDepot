using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.Stores
{
    public class UsersStore
    {
        private readonly UserDataProvider _userDataProvider;
        private List<User> _users;

        public IEnumerable<User> Users { get { return _users; } }
        public UserDataProvider UsersDB { get { return _userDataProvider; } }

        public event Action UsersLoaded;

        public UsersStore(UserDataProvider projectDataProvider)
        {
            _userDataProvider = projectDataProvider;
            _users = new List<User>();
        }

        public async Task Load()
        {
            _users.Clear();

            IEnumerable<User> usersFromDB = await _userDataProvider.GetAllUsers();
            _users.AddRange(usersFromDB);

            UsersLoaded?.Invoke();
        }
    }
}
