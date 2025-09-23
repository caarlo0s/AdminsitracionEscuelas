using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class Users : AuditableEntity<Guid>, IAggregateRoot
    {
        public Users(string userName, string email, string completeName, string passwordHash, bool isActive)
        {
            UserName = userName;
            Email = email;
            CompleteName = completeName;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }
        public Users(string userName, string email, string completeName, string passwordHash, bool isActive,string createdby)
        {
            Id= Guid.NewGuid();
            UserName = userName;
            Email = email;
            CompleteName = completeName;
            PasswordHash = passwordHash;
            IsActive = isActive;
            CreatedBy = "System"; 
            CreatedOn = DateTime.UtcNow;
            LastModifiedBy = "System";
            LastModified = DateTime.UtcNow; IsDeleted = false; DeletedBy = "";
        }

        public static Users Create(string userName, string email, string completeName, string passwordHash, bool isActive)
        {
            return new Users(userName, email, completeName, passwordHash, isActive);
        }

        public Users Update(string userName, string email, string completeName, string? newPasswordPlainText)
        {
            UserName = userName;
            Email = email;
            CompleteName = completeName;

            if (!string.IsNullOrWhiteSpace(newPasswordPlainText))
            {
                // Verificamos si la contraseña actual es igual a la almacenada
                bool samePassword = BCrypt.Net.BCrypt.Verify(newPasswordPlainText, PasswordHash);

                if (!samePassword)
                {
                    // Si es distinta, generamos un nuevo hash
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPasswordPlainText);
                }
                // Si es la misma, no tocamos PasswordHash
            }
            return this;
        }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string CompleteName { get; private set; }
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    }

}

