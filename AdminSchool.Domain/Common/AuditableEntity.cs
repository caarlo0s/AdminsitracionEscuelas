using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Common
{
    public abstract class AuditableEntity<TId> : Entity<TId>, IAuditableEntity where TId : notnull
    {
        protected AuditableEntity() { }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string  LastModifiedBy {get;set; } = string.Empty;
        public DateTime LastModified { get; set; } = DateTime.MinValue;

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; } = string.Empty;
        public DateTime DeleteAt { get; set; }  = DateTime.MinValue;
        public override bool Equals(object? obj)
        {
            return obj is AuditableEntity<TId> other && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(AuditableEntity<TId> left, AuditableEntity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AuditableEntity<TId> left, AuditableEntity<TId> right) {
            return Equals(left, right);
        }
    }
}
