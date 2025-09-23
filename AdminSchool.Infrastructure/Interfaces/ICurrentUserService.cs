using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserName { get; }
    }
}
