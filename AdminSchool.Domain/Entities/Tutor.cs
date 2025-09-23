using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{

    public class Tutor : AuditableEntity<int>, IAggregateRoot
    {
        public string CompleteName { get; set; }

        public string Phone { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
