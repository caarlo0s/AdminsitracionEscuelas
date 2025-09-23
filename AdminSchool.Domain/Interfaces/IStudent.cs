using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Interfaces
{
    public interface IStudent : IRepository<Student>
    {
       Task< List<Student>> GetAllStudents(int page, int pageSize, int? gradeId, int? groupId, string? searchText);
    }
}
