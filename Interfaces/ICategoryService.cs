using FinanceTrackerTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerTemplate.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(string name, string type);
        List<Category> GetAllCategories();
        bool CategoryExists(string name);
    }
}
