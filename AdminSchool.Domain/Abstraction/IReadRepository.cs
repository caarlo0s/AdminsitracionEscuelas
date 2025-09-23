using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Abstraction
{
    public interface IReadRepository<TEntity> where TEntity : class,IAggregateRoot
    {
        Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default(CancellationToken)) where TId : notnull;

        Task<IReadOnlyList<TEntity>> GetListAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountAsync(CancellationToken cancellationToken = default(CancellationToken)); 

        Task<bool>AnyAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
