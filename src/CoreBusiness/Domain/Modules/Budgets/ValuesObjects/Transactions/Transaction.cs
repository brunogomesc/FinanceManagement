using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Budgets.ValuesObjects.Transactions
{
    public record Transaction(DateTime CreatedAt, string Description, decimal Value)
    {
    }
}
