using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Repositories.Interfaces;
using FinanceTrackerTemplate.Services.Interfaces;

namespace FinanceTrackerTemplate.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddTransaction(decimal amount, bool isIncome, string category, string description)
        {
            var transaction = new Transaction
            {
                Id = _transactionRepository.GetNextId(),
                Amount = amount,
                IsIncome = isIncome,
                Category = category,
                Description = description,
                Date = DateTime.Now
            };


            _transactionRepository.Add(transaction); 
        }
        public void DeleteTransaction(int id)
        {
            _transactionRepository.DeleteById(id);
        }

        public List<Transaction> GetAllTransactions() => _transactionRepository.GetAll();

        public decimal GetBalance() => _transactionRepository.GetBalance();
    }

}


