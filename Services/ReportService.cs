using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Interfaces;
using FinanceTrackerTemplate.Repositories.Interfaces;




namespace FinanceTrackerTemplate.Services
{
    public class ReportService : IReportService
    {
        private readonly ITransactionRepository _transactionRepository;

        public ReportService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void GenerateReport()
        {
            Console.Clear();
            Console.WriteLine("=== Summary Report ===");

            var transactions = _transactionRepository.GetAll();
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            decimal totalIncome = transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => !t.IsIncome).Sum(t => t.Amount);
            decimal balance = totalIncome - totalExpense;

            Console.WriteLine($"Total Income: {totalIncome}$");
            Console.WriteLine($"Total Expenses: {totalExpense}$");
            Console.WriteLine($"Current Balance: {balance}$");
        }
    }

}

