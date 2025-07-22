using Application.Abstractions.Ports.Repositories;
using Domain.Abstractions.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Postgres.Databases
{
    public class FinanceManagementRepository : IFinanceManagementRepository
    {

        private readonly DbContext _context;

        public FinanceManagementRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) 
            where TEntity : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) 
            where TEntity : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync<TEntity, TProperty>(Expression<Func<TEntity, bool>> expression, TProperty property, CancellationToken cancellationToken)
            where TEntity : class
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var entity = await _context.Set<TEntity>().FirstAsync(expression, cancellationToken);

            _context.Attach(entity);
            _context.Entry(entity).Property(nameof(TProperty)).CurrentValue = property;
            
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) 
            where TEntity : class
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var entity = await _context.Set<TEntity>().FindAsync(expression, cancellationToken);

            if(entity == null)
                throw new InvalidOperationException("Entity not found");

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) 
            where TEntity : class
        {
            
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken);

        }

        public async Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) 
            where TEntity : class
        {

            return await _context.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);

        }

    }
}
