using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string username, IEnumerable<string> roles);
    }
}
