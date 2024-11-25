using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.Stores
{
    public class CategoriesStore
    {
        private readonly CategoryDataProvider _categoryDataProvider;
        private List<Category> _categories;

        public IEnumerable<Category> Categories { get { return _categories; } }
        public CategoryDataProvider DB { get { return _categoryDataProvider; } }

        public event Action CategoriesLoaded;

        public CategoriesStore(CategoryDataProvider categoryDataProvider)
        {
            _categoryDataProvider = categoryDataProvider;
            _categories = new List<Category>();
        }

        public async Task Load()
        {
            _categories.Clear();

            IEnumerable<Category> categoriesFromDB = await _categoryDataProvider.GetAllCategories();
            _categories.AddRange(categoriesFromDB);

            CategoriesLoaded?.Invoke();
        }
    }
}
