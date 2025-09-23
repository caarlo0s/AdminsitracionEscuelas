using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class Grade : AuditableEntity<int>, IAggregateRoot
    {
        public Grade(string name, int educationLevelId)
        {
            Name = name;
            EducationLevelId = educationLevelId;
        }

        public string Name { get; set; }
        public int EducationLevelId { get; set; }

        public Grade Create(string name, int educationLevelId)
        {
            return new Grade(name, educationLevelId);
        }
        public Grade Update(string name, int educationLevelId)
        {
            Name = name;
            EducationLevelId = educationLevelId;
            return this;
        }
        public EducationLevel EducationLevel { get; set; }

        public List<GroupSchool> Groups { get; set; } = new();
    }
}
