using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Services.Interfaces;
using FinanceTrackerTemplate.Interfaces;

namespace FinanceTrackerTemplate.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(string name, string type)
        {
            _categoryRepository.Add(new Category { Name = name, Type = type });
        }

        public List<Category> GetAllCategories() => _categoryRepository.GetAll();

        public bool CategoryExists(string name) => _categoryRepository.Exists(name);
    }
}


