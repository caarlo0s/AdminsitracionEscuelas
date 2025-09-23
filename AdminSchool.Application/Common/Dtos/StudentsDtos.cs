using AdminSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Common.Dtos
{
    public class StudentsDtos
    {
    }

    public class GetAllStudentsDto
    {

        public string? Name { get; set; }



        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public DateTime Bithday { get; set; }

        public string GroupName { get; set; }
        public string GradeName { get; set; }

        public List<TutorsStudentDto> Tutors { get; set; }

    }

    public class GetStudentById
    {
        public string? Name { get; set; }



        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public DateTime Bithday { get; set; }

        public string Age { get; set; }

     
        public int GroupId { get; set; }
        
        public int GradeId { get; set; }
    }
}
