using Application.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Ports.Handlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {

        Task Handle(TCommand command, CancellationToken cancellationToken);

    }
}
