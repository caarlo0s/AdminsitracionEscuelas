using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Common
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string LastModifiedBy { get; set; }
        DateTime LastModified { get; set; }
        string DeletedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
