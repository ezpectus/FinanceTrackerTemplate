using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTrackerTemplate.Models;



namespace FinanceTrackerTemplate.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        List<Transaction> GetAll();
        decimal GetBalance();
        int GetNextId();
        void DeleteById(int id);
    }
}
