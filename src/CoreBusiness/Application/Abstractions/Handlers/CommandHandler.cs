using Application.Abstractions.Contracts;
using Application.Abstractions.Ports.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Handlers
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {

        public abstract Task Handle(TCommand command, CancellationToken cancellationToken ); 

    }
}
