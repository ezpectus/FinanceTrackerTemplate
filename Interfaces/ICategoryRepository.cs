using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTrackerTemplate.Models;

namespace FinanceTrackerTemplate.Services.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        List<Category> GetAll();
        bool Exists(string name);
    }
}