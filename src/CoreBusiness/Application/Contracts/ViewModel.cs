using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public static class ViewModel
    {

        public record BalanceViewModel(Guid AccountId, decimal Income, decimal Expense);

        public record CategoryViewModel(Guid AccountId, string Name, decimal Limit);

        public record TransactionViewModel(Guid AccountId, string Category, DateTime CreatedAt, string Description, decimal Value);

    }
}
