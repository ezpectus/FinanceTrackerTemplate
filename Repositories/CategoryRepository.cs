
// CategoryRepository.cs
using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Services.Interfaces;

namespace FinanceTrackerTemplate.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDataStorageService _storageService;
        private DataStorage _storage;

        public CategoryRepository(IDataStorageService storageService)
        {
            _storageService = storageService;
            _storage = _storageService.Load();
        }

        public void Add(Category category)
        {
            _storage.Categories.Add(category);
            _storageService.Save(_storage);
        }

        public List<Category> GetAll() => _storage.Categories;

        public bool Exists(string name) =>
            _storage.Categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

}
