using Domain.Modules.Budgets.ValuesObjects.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Budgets.ValuesObjects.Categories
{
    public record Category(string Name, decimal Limit)
    {
        private readonly List<Transaction> _transactions = [];

        public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();

        public void RegisterTransaction(DateTime createdAt, string description, decimal value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Transaction value must be greater than zero.");

            var transaction = new Transaction(createdAt, description, value);

            _transactions.Add(transaction);
        }
    }
}
