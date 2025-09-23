using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AdminSchool.Infrastructure.Repositories
{
    public class EducationLevelRepository(AdminDbContext context):BaseRepository<EducationLevel,AdminDbContext>(context), IEducationLevel
    {
        private readonly AdminDbContext _context = context;


        public async Task<List<EducationLevel>> GetAllPaginatedEducationLevel(int page, int pageSize, string? searchText)
        {
            var query =  _context.EducationLevels.Include(x=>x.Grades).ThenInclude(x=>x.Groups)
                .AsNoTracking()
                .Where(x => !x.IsDeleted);
           
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(x =>
                    x.Name.Contains(searchText));
            }

            return await query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
        }
    }
}
