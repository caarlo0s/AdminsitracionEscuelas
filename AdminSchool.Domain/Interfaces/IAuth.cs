using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Interfaces
{
    public interface IAuth : IRepository<Users>
    {
        Task<Users> LogIn(string username, string password);
    }
}
