using ElectroDepotClassLibrary.Models;

namespace DesktopClient.Containers
{
    public class DetailedComponentContainer
    {
        public int ID { get { return Component.ID; } }
        public int CategoryID { get { return Component.CategoryID; } }
        public Category Category { get { return Component.Category; } }
        public string Name { get { return Component.Name; } }
        public string Manufacturer { get { return Component.Manufacturer; } }
        public string Description { get { return Component.Description; } }
        public int Available { get; }
        public Component Component { get; }

        public DetailedComponentContainer(Component component, int available)
        {
            Component = component;
            Available = available;
        }
    }
}
