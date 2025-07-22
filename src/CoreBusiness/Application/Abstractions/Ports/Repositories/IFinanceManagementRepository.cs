using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Ports.Repositories
{
    public  interface IFinanceManagementRepository
    {

        Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) 
            where TEntity : class;

        Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) 
            where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) 
            where TEntity : class;

        Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) 
            where TEntity : class;
    }
}
