using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValuesObjects.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.Budgets.CommandHandlers
{
    public class AddCategoryHandler : CommandHandler<Command.AddCategoryCommand>
    {

        private readonly IFinanceManagementRepository _repository;

        public AddCategoryHandler(IFinanceManagementRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override async Task Handle(Command.AddCategoryCommand command, CancellationToken cancellationToken)
        {

            Budget? budget = await _repository.GetAsync<Budget>(prop => prop.Id == command.BudgetId, cancellationToken);

            if (budget == null)
            {
                throw new InvalidOperationException($"Budget with ID {command.BudgetId} not found.");
            }

            Category category = new Category(command.category.Name, command.category.Limit);

            budget.AddCategory(category);

            await _repository.UpdateAsync(budget, cancellationToken);
        }
    }
}
