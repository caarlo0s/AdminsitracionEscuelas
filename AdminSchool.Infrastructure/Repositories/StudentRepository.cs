using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Repositories
{
    public class StudentRepository(AdminDbContext context) :
        BaseRepository<Student,AdminDbContext>(context),IStudent
    {
        private readonly AdminDbContext _context = context;

        public async Task<List<Student>> GetAllStudents(int page, int pageSize, int? gradeId, int? groupId, string? searchText)
        {
            var query = _context.Students
                .Include(x => x.Tutors)
                .Include(x => x.Group)
                .AsNoTracking()
                .Where(x => !x.IsDeleted); // Por ejemplo, si tienes lógica de borrado lógico

            if (gradeId.HasValue)
            {
                query = query.Where(x => x.Group.GradeId == gradeId.Value);
            }

            if (groupId.HasValue)
            {
                query = query.Where(x => x.GroupId == groupId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(x =>
                    x.Name.Contains(searchText) ||
                    x.LastName.Contains(searchText) ||
                    x.MiddleName.Contains(searchText));

            }

            return await query
                .OrderBy(x => x.MiddleName).OrderBy(x=>x.LastName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
