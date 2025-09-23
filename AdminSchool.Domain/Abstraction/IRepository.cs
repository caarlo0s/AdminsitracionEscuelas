using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Abstraction
{
    public interface IRepository<TRoot> :IReadRepository<TRoot> where TRoot : class,IAggregateRoot
    {
        Task<TRoot> AddAsync(TRoot entity,CancellationToken cancellationToken=default(CancellationToken));

        Task<IEnumerable<TRoot>> AddRangeAsync(IEnumerable<TRoot> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateAsync(TRoot entity, CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateRangeasync(IEnumerable<TRoot> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(TRoot entity, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteRangeAsync(IEnumerable<TRoot> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
