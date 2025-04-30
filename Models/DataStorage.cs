using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerTemplate.Models
{
    public class DataStorage
    {
        public int LastTransactionId { get; set; } = 0;
        public List<Transaction> Transactions { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
    }
}

