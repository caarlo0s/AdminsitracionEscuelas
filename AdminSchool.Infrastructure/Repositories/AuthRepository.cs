using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace AdminSchool.Infrastructure.Repositories
{
    public class AuthRepository(AdminDbContext context) : 
        BaseRepository<Users, AdminDbContext>(context), 
        IAuth
    {
        private readonly AdminDbContext _context = context;

        public async Task<Users?> LogIn(string username, string password) {
            var user = await _context.Users
        .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
        .FirstOrDefaultAsync(u => u.UserName == username);

            if (user is null)
                return null;

            // ⚠️ Validar el password hasheado (usa BCrypt o similar)
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return isPasswordValid ? user : null;

        }

    }
}
