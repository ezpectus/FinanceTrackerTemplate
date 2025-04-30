using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Services.Interfaces;
using FinanceTrackerTemplate.UI;
using FinanceTrackerTemplate.Interfaces;

namespace FinanceTrackerTemplate.Models.Repositories.Interfaces
{
   
    public interface IDataStorageService
    {
        void Save(DataStorage storage);
        DataStorage Load();
      
    }
}