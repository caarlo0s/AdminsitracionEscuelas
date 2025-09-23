using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class GroupSchool :AuditableEntity<int>, IAggregateRoot
    {
        public GroupSchool(string name, int gradeId)
        {
            Name = name;
            GradeId = gradeId;
        }
        public GroupSchool Create(string name, int gradeId)
        {
         return new GroupSchool(name, gradeId); 
        }
        public GroupSchool Upadate(string name, int gradeId)
        {
            Name = name;
            GradeId= gradeId;

            return this;
        }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
