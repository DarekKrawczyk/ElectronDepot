using ElectroDepotClassLibrary.DTOs;

namespace ElectroDepotClassLibrary.DataProviders
{
    public interface ICategoryDataProvider
    {
        Task<bool> CreateCategory(CreateCategoryDTO category);
        Task<bool> DeleteCategory(CategoryDTO category);
        Task<bool> DeleteCategory(int ID);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryByID(int ID);
        Task<CategoryDTO> GetCategoryByName(string name);
        Task<bool> UpdateCategory(CategoryDTO category);
    }
}