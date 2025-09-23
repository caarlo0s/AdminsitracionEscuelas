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
    public class PermissionRepository(AdminDbContext context) : BaseRepository<Permission, AdminDbContext>(context), IPermission
    {
    }
}
