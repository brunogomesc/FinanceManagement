using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using Domain.Modules.Accounts.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.Accounts.CommandHandlers
{
    public class CreateAccountHandler : CommandHandler<Command.CreateAccountCommand>
    {

        private readonly IFinanceManagementRepository _repository;

        public CreateAccountHandler(IFinanceManagementRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override async Task Handle(Command.CreateAccountCommand command, CancellationToken cancellationToken)
        {
            
            Account account = new();

            account.Create(command.FirstName, command.LastName, command.Email);

            await _repository.InsertAsync(account, cancellationToken);

        }

    }
}
