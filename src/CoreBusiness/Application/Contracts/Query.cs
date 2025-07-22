using Application.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public static class Query
    {

        public record GetBalanceQuery(Guid AccountId)
        : IQuery;

        public record ListCategoryQuery(Guid AccountId)
        : IQuery;

        public record ListExpenseByCategoryQuery(Guid AccountId, string Category)
        : IQuery;

        public record ListTransactionQuery(Guid AccountId, DateTime? CreatedAt)
        : IQuery;

    }
}
