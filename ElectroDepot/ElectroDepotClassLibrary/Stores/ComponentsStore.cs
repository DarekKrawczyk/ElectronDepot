using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;
using System.Collections.Generic;

namespace ElectroDepotClassLibrary.Stores
{
    public class ComponentsStore
    {
        private readonly ComponentDataProvider _componentDataProvider;
        private List<Component> _components;

        public IEnumerable<Component> Components {  get { return _components; } }
        public ComponentDataProvider DB { get { return _componentDataProvider; } }

        public event Action ComponentsLoaded;

        public ComponentsStore(ComponentDataProvider componentDataProvider)
        {
            _componentDataProvider = componentDataProvider;
            _components = new List<Component>();
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
