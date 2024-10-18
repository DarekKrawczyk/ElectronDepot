using ElectroDepotClassLibrary.DTOs;

namespace ElectroDepotClassLibrary.DataProviders
{
    public interface IComponentDataProvider
    {
        Task<bool> CreateComponent(CreateComponentDTO category);
        Task<bool> DeleteComponent(ComponentDTO component);
        Task<bool> DeleteComponent(int ID);
        Task<IEnumerable<ComponentDTO>> GetAllComponents();
        Task<ComponentDTO> GetComponentByID(int ID);
        Task<ComponentDTO> GetComponentByName(string name);
        Task<bool> UpdateComponent(ComponentDTO component);
    }
}