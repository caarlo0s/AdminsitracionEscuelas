using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class Student : AuditableEntity<int>,IAggregateRoot
    {
        public string? Name { get; set; }



        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public DateTime Bithday { get; set; }

        public string Age { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();
        public List<Tutor> Tutors { get; set; } = new List<Tutor>();
        public int GroupId { get; set; }
        public GroupSchool Group { get; set; }
        public List<StudentNote> Notes { get; set; } = new();



    }
}
