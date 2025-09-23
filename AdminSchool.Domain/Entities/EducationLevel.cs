using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class EducationLevel : AuditableEntity<int>,IAggregateRoot
    {
        public string Name { get; set; }
        public List<Grade> Grades { get; set; } = new();

        public EducationLevel(string name) {
            Name=name;
        }

        public static EducationLevel Create(string name) {
            return new EducationLevel(name);
        }
        public EducationLevel Update(string name) { Name = name; return this; }


    }
}
