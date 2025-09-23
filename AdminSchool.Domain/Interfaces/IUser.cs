using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using AdminSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Interfaces
{
    public interface IUser : IRepository<Users>
    {
        Task<List<Users>> GetAllUsers(int page, int pageSize);
        Task<Users> GetUserByUserName(string userName);
    }
}
