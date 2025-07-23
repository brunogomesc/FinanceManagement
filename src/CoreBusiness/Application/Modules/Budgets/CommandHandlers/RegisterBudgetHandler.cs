using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using Domain.Modules.Budgets.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.Budgets.CommandHandlers
{
    public class RegisterBudgetHandler : CommandHandler<Command.RegisterBudgetCommand>
    {

        private readonly IFinanceManagementRepository _repository;

        public RegisterBudgetHandler(IFinanceManagementRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override async Task Handle(Command.RegisterBudgetCommand command, CancellationToken cancellationToken)
        {
            Budget budget = new();

            budget.Register(command.AccountId, command.ReferencePeriod, command.TotalValue);

            await _repository.InsertAsync(budget, cancellationToken);

        }
    }
}
