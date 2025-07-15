using Application.Abstractions.Contracts;
using Application.Abstractions.Ports.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Handlers
{
    public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery
    {

        public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);

    }
}
