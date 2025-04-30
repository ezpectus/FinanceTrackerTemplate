using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceTrackerTemplate.Interfaces;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Services.Interfaces;
using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.UI;

using FinanceTrackerTemplate.Services;
using FinanceTrackerTemplate.Models.Repositories;

namespace FinanceTrackerTemplate.Interfaces
    {
        public interface IReportService
        {
            void GenerateReport();
        }
    }


