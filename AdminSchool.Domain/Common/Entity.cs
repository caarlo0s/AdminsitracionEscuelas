using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Common
{
    public abstract class Entity<TId> where TId : notnull
    {
        public TId Id { get; set; }
    }
}
