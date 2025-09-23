using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Persistence
{
    public class BaseRepository<TRoot, TContext> : IRepository<TRoot>, IReadRepository<TRoot> where TRoot : class, IAggregateRoot where TContext : DbContext
    {
      
        protected readonly TContext _dbContext;



        public BaseRepository(TContext dbContext)

        {

            _dbContext = dbContext;

        }
        public async Task<TRoot> AddAsync(TRoot entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TRoot>().AddAsync(entity, cancellationToken);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TRoot>> AddRangeAsync(IEnumerable<TRoot> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TRoot>().AddRangeAsync(entities, cancellationToken);

            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return (await EntityFrameworkQueryableExtensions.ToListAsync(_dbContext.Set<TRoot>())).Any();
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {

            return (await EntityFrameworkQueryableExtensions.ToListAsync(_dbContext.Set<TRoot>())).Count;
        }

        public async Task DeleteAsync(TRoot entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TRoot>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<TRoot> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<IEnumerable<TRoot>>().RemoveRange(entities);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TRoot?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _dbContext.Set<TRoot>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TRoot>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(_dbContext.Set<TRoot>());
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TRoot entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeasync(IEnumerable<TRoot> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<IEnumerable<TRoot>>().UpdateRange(entities);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
