using ElectroDepotClassLibrary.DTOs;

namespace ElectroDepotClassLibrary.Models
{
    public class Component
    {
        public int ID { get; }
        public int CategoryID { get; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public Component(int id, int categoryID, Category category, string name, string manufacturer, string description)
        {
            ID = id;
            CategoryID = categoryID;
            Category = category;
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
        }

        public override string ToString()
        {
            return $"ID: '{ID}', Name: '{Name}', Manufacturer: '{Manufacturer}', Description: '{Description}', CategoryID: '{CategoryID}'";
        }
    }

    public static class ComponentExtensionMethods
    {
        public static ComponentDTO ToDTO(this Component component)
        {
            return new ComponentDTO(ID: component.ID, CategoryID: component.CategoryID, Name: component.Name, Manufacturer: component.Manufacturer, Description: component.Description);
        }
        public static UpdateComponentDTO ToUpdateDTO(this Component component)
        {
            return new UpdateComponentDTO(Name: component.Name, Manufacturer: component.Manufacturer, Description: component.Description);
        }
        public static CreateComponentDTO ToCreateDTO(this Component component)
        {
            return new CreateComponentDTO(CategoryID: component.CategoryID, Name: component.Name, Manufacturer: component.Manufacturer, Description: component.Description);
        }
        public static Component ToModel(this ComponentDTO componentDTO)
        {
            return new Component(id: componentDTO.ID, categoryID: componentDTO.CategoryID, category: null, name: componentDTO.Name, manufacturer: componentDTO.Manufacturer, description: componentDTO.Description);
        }
    }
}