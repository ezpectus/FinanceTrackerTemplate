using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceTrackerTemplate.Models;

namespace FinanceTrackerTemplate.Services.Interfaces
{
    public interface ITransactionService
    {
        void AddTransaction(decimal amount, bool isIncome, string category, string description);
        void DeleteTransaction(int id);
        List<Transaction> GetAllTransactions();
        decimal GetBalance();
    }
}
