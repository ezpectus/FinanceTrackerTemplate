
// TransactionRepository.cs
using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Repositories.Interfaces;
using FinanceTrackerTemplate.Services.Interfaces;


namespace FinanceTrackerTemplate.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDataStorageService _storageService;
        private DataStorage _storage;

        public TransactionRepository(IDataStorageService storageService)
        {
            _storageService = storageService;
            _storage = _storageService.Load();
        }

        public void Add(Transaction transaction)
        {
            _storage.Transactions.Add(transaction);
            _storageService.Save(_storage); 
        }
        public int GetNextId()
        {
            _storage.LastTransactionId++;
            _storageService.Save(_storage); 
            return _storage.LastTransactionId;
        }
        public void DeleteById(int id)
        {
            var transaction = _storage.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction != null)
            {
                _storage.Transactions.Remove(transaction);
                _storageService.Save(_storage);
            }
        }

        public List<Transaction> GetAll() => _storage.Transactions;

        public decimal GetBalance()
        {
            return _storage.Transactions
                .Sum(t => t.IsIncome ? t.Amount : -t.Amount);
        }
    }
}
