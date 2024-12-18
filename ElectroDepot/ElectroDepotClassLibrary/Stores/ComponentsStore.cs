using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;
using System.Collections.Generic;

namespace ElectroDepotClassLibrary.Stores
{
    public class ComponentsStore
    {
        private readonly ComponentDataProvider _componentDataProvider;
        private readonly OwnsComponentDataProvider _ownsComponentDataProvider;
        private List<Component> _components;

        public IEnumerable<Component> Components {  get { return _components; } }
        public ComponentDataProvider DB { get { return _componentDataProvider; } }
        public OwnsComponentDataProvider OwnsCompDB { get { return _ownsComponentDataProvider; } }

        public event Action ComponentsLoaded;

        public ComponentsStore(ComponentDataProvider componentDataProvider, OwnsComponentDataProvider ownsComponentDataProvider)
        {
            _componentDataProvider = componentDataProvider;
            _ownsComponentDataProvider = ownsComponentDataProvider;
            _components = new List<Component>();
            // TODO: OwnsComponent model requires implementation of User model just like the rest of Models....
        }

        public async Task Load()
        {
            _components.Clear();

            IEnumerable<Component> componentsFromDB = await _componentDataProvider.GetAllComponents();
            _components.AddRange(componentsFromDB);

            ComponentsLoaded?.Invoke();
        }
    }
}
