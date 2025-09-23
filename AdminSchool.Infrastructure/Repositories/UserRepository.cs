using AdminSchool.Application.Common.Dtos;
using AdminSchool.Domain.Common;
using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Repositories
{
    public class UserRepository(AdminDbContext context) : BaseRepository<Users, AdminDbContext>(context), IUser
    {
        private readonly AdminDbContext _context = context;


        public async Task<Users> GetUserByUserName(string userName)
        {

                var user = await _context.Users.Where(x => x.UserName.Equals(userName)).FirstOrDefaultAsync();
                return user;

        }

        public async Task<List<Users>> GetAllUsers(int page, int pageSize)
        {
            var totalCount = await _dbContext.Users.CountAsync();

            var users = await _dbContext.Users
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }
    }
}
