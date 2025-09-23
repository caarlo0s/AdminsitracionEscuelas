using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class Teacher : AuditableEntity<int>,IAggregateRoot
    {
        public string CompleteName { get; set; }
        public List<StudentNote> Notes { get; set; } = new();
    }
}
