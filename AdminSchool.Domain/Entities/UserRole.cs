using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{

    public class UserRole :AuditableEntity<Guid>,IAggregateRoot
    {
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
