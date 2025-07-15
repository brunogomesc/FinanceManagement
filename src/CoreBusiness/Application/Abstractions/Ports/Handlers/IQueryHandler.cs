using Application.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Ports.Handlers
{
    public interface IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery
    {

        Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);

    }
}
