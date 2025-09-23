using AdminSchool.Domain.Common;
using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Persistence
{
    public class AdminDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUser;
        public AdminDbContext(DbContextOptions options,ICurrentUserService currentUser) : base(options)
        {
            _currentUser = currentUser;
        }

        #region Entities from AdminSchool
        public DbSet<Document> Documents { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GroupSchool> GroupSchools { get; set; }
        public DbSet<PaymentConcept> PaymentConcepts { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentNote> StudentNotes { get; set; }
        public DbSet<StudentPayment> StudentPayments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ========== EducationLevel -> Grades ==========
            builder.Entity<EducationLevel>()
                .HasMany(e => e.Grades)
                .WithOne(g => g.EducationLevel)
                .HasForeignKey(g => g.EducationLevelId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== Grade -> Groups ==========
            builder.Entity<Grade>()
                .HasMany(g => g.Groups)
                .WithOne(gr => gr.Grade)
                .HasForeignKey(gr => gr.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== Group -> Students ==========
            builder.Entity<GroupSchool>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== Student -> Tutors (Many-to-Many) ==========
            builder.Entity<Student>()
                .HasMany(s => s.Tutors)
                .WithMany(t => t.Students)
                .UsingEntity(j =>
                    j.ToTable("StudentTutors") // tabla intermedia generada por EF Core
                );

            // ========== Student -> Documents (One-to-Many) ==========
            builder.Entity<Document>()
                .HasOne(d => d.Student)
                .WithMany(s => s.Documents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== Student -> Payments (One-to-Many) ==========
            builder.Entity<StudentPayment>()
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== Payment -> Concept (Many-to-One) ==========
            builder.Entity<StudentPayment>()
                .HasOne(p => p.PaymentConcept)
                .WithMany()
                .HasForeignKey(p => p.PaymentConceptId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== Payment -> SchoolYear (Many-to-One) ==========
            builder.Entity<StudentPayment>()
                .HasOne(p => p.SchoolYear)
                .WithMany(y => y.StudentPayments)
                .HasForeignKey(p => p.SchoolYearId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentNote>()
        .HasOne(n => n.Student)
        .WithMany(s => s.Notes)
        .HasForeignKey(n => n.StudentId)
        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentNote>()
                .HasOne(n => n.Teacher)
                .WithMany(t => t.Notes)
                .HasForeignKey(n => n.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PaymentConcept>()
           .Property(p => p.DefaultAmount)
           .HasPrecision(18, 2);

            builder.Entity<StudentPayment>()
                .Property(p => p.AmountPaid)
                .HasPrecision(18, 2);

            builder.Entity<Users>();

            builder.Entity<UserRole>()
          .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            builder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // RolePermission (many-to-many)
            builder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            builder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);


        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userName = _currentUser.UserName ?? "System";
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IAuditableEntity auditable) // o directamente AuditableEntity<TId>
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditable.CreatedOn = now;
                            auditable.CreatedBy = userName;
                            break;

                        case EntityState.Modified:
                            auditable.LastModified = now;
                            auditable.LastModifiedBy = userName;
                            break;

                        case EntityState.Deleted:
                            auditable.IsDeleted = true;
                            auditable.DeletedBy = userName;
                            auditable.LastModified = now;
                            auditable.LastModifiedBy = userName;

                            entry.State = EntityState.Modified; // convierte borrado físico en lógico
                            break;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
