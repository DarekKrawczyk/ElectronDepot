using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;
using System.Collections.Generic;

namespace ElectroDepotClassLibrary.Stores
{
    public class ComponentsStore : RootStore
    {
        private readonly ComponentDataProvider _componentDataProvider;
        private readonly OwnsComponentDataProvider _ownsComponentDataProvider;
        private List<Component> _components;
        private List<OwnsComponent> _ownedComponents;
        private List<OwnsComponent> _unusedComponents;

        public IEnumerable<Component> Components {  get { return _components; } }
        public IEnumerable<OwnsComponent> OwnedComponents {  get { return _ownedComponents; } }
        public IEnumerable<OwnsComponent> UnusedComponents {  get { return _unusedComponents; } }
        
        public ComponentDataProvider ComponentDP { get { return _componentDataProvider; } }
        public OwnsComponentDataProvider OwnsComponentDP { get { return _ownsComponentDataProvider; } }

        public event Action ComponentsLoaded;

        public ComponentsStore(DatabaseStore dbStore, ComponentDataProvider componentDataProvider, OwnsComponentDataProvider ownsComponentDataProvider) : base(dbStore)
        {
            _componentDataProvider = componentDataProvider;
            _ownsComponentDataProvider = ownsComponentDataProvider;
            _components = new List<Component>();
            _ownedComponents = new List<OwnsComponent>();
            _unusedComponents = new List<OwnsComponent>();
            // TODO: OwnsComponent model requires implementation of User model just like the rest of Models....
        }

        public async Task Load()
        {
            User loggedInUser = MainStore.UsersStore.LoggedInUser;
            if (loggedInUser == null) throw new Exception("User not logged in!!");

            IEnumerable<OwnsComponent> ownedComponentsFromDB = await OwnsComponentDP.GetAllOwnsComponentsFromUser(loggedInUser);
            IEnumerable<Component> componentsFromDB = await ComponentDP.GetAllAvailableComponentsFromUser(loggedInUser);
            IEnumerable<OwnsComponent> unusedComponentsFromDB = await OwnsComponentDP.GetAllUnusedComponents(loggedInUser);

            if (ownedComponentsFromDB.Count() != componentsFromDB.Count() || componentsFromDB.Count() != unusedComponentsFromDB.Count()) throw new Exception("Data retrieved from db doesn't match!!!");

            _ownedComponents.AddRange(ownedComponentsFromDB);
            _components.AddRange(componentsFromDB);
            _unusedComponents.AddRange(unusedComponentsFromDB);

            ComponentsLoaded?.Invoke();
        }
    }
}
