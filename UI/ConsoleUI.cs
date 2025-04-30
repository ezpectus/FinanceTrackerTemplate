using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Services;
using FinanceTrackerTemplate.Services.Interfaces;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;


using FinanceTrackerTemplate.Interfaces;

namespace FinanceTrackerTemplate.UI
{
    public class ConsoleUI
    {
        private readonly ITransactionService _transactionService;
        private readonly IReportService _reportService;
        private readonly IDataStorageService _storageService;

        public ConsoleUI(ITransactionService transactionService, IReportService reportService, IDataStorageService storageService)
        {
            _transactionService = transactionService;
            _reportService = reportService;
            _storageService = storageService;
        }

        public void Run()
        {
            _storageService.Load();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== FINANCE TRACKER ====");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View All Transactions");
                Console.WriteLine("3. Show Summary Report");
                Console.WriteLine("4. Delete Transaction by ID");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTransaction();
                        break;
                    case "2":
                        ShowTransactions();
                        break;
                    case "3":
                        _reportService.GenerateReport();
                        Pause();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("=== Delete Transaction by ID ===");
                        Console.Write("Enter transaction ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out var id))
                        {
                            _transactionService.DeleteTransaction(id);
                            Console.WriteLine("[INFO] Transaction deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("[ERROR] Invalid ID.");
                        }
                        Pause();
                        break;
                    case "0":
                        Console.WriteLine("\nExiting app...");
                        return;
                    default:
                        Console.WriteLine("[ERROR] Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        private void AddTransaction()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Transaction ===");

            Console.Write("Enter amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("[ERROR] Invalid amount.");
                Pause();
                return;
            }

            Console.Write("Is it income? (yes/no): ");
            var incomeInput = Console.ReadLine()?.ToLower();
            bool isIncome = incomeInput == "yes";

            Console.Write("Enter category: ");
            var category = Console.ReadLine() ?? "Uncategorized";

            Console.Write("Enter description (optional): ");
            var description = Console.ReadLine() ?? "";

            _transactionService.AddTransaction(amount, isIncome, category, description);
            Console.WriteLine("[INFO] Transaction added successfully.");
            Pause();
        }

        private void ShowTransactions()
        {
            Console.Clear();
            Console.WriteLine("=== All Transactions ===");

            var transactions = _transactionService.GetAllTransactions();
            if (transactions.Count == 0)
            {
                Console.WriteLine("[INFO] No transactions found.");
                Pause();
                return;
            }

            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.Id}: {t.Amount}₽ | {(t.IsIncome ? "Income" : "Expense")} | {t.Category} | {t.Date.ToShortDateString()} | {t.Description}");
            }

            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
