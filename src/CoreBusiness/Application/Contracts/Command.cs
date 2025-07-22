using Application.Abstractions.Contracts;
using Domain.Modules.Budgets.ValuesObjects.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public static class Command
    {

        public record AddCategoryCommand(Category category)
        : Message, ICommand;

        public record CreateAccountCommand(string FirstName, string LastName, string Email)
        : Message, ICommand;

        public record InformAddressCommand(string Street, string City, string State, string ZipCode, string Country, int? Number, string? Complement)
        : Message, ICommand;

        public record RegisterBudgetCommand(Guid AccountId, DateOnly ReferencePeriod, decimal TotalValue)
        : Message, ICommand;

        public record RegisterTransactionCommand(string Category, DateTime CreatedAt, string Description, decimal Value)
        : Message, ICommand;

        public record UpdateTotalLimitCommand(decimal TotalValue)
        : Message, ICommand;

    }
}
