using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Repositories
{
    internal class RoleRepository(AdminDbContext context) : BaseRepository<Role, AdminDbContext>(context), IRole
    {
    }
}
