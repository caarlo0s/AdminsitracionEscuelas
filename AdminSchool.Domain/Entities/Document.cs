using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class Document : AuditableEntity<int>,IAggregateRoot
    {
        public string TypeDocument { get; set; }
        public string Url { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
