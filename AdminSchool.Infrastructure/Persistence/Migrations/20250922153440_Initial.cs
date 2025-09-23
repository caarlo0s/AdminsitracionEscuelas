using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminSchool.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("005e3089-816a-4d59-b1e7-9b01d8db155c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("685828e5-7a7c-4123-9ef9-a8abdfcc4f69"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7b9ab63a-f1a3-4ced-8a78-366f37705cd6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab2a04b3-497a-4245-a18c-2d8a7baa0d71"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62de4eb3-cdd5-4419-88eb-0cdd707cd217"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "IsDeleted", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("005e3089-816a-4d59-b1e7-9b01d8db155c"), "System", new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(2279), "", false, new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(2281), "System", "maestro" },
                    { new Guid("685828e5-7a7c-4123-9ef9-a8abdfcc4f69"), "System", new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(2283), "", false, new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(2283), "System", "finanzas" },
                    { new Guid("7b9ab63a-f1a3-4ced-8a78-366f37705cd6"), "System", new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(2285), "", false, new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(2286), "System", "contable" },
                    { new Guid("ab2a04b3-497a-4245-a18c-2d8a7baa0d71"), "System", new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(1555), "", false, new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(1864), "System", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompleteName", "CreatedBy", "CreatedOn", "DeletedBy", "Email", "IsActive", "IsDeleted", "LastModified", "LastModifiedBy", "PasswordHash", "UserName" },
                values: new object[] { new Guid("62de4eb3-cdd5-4419-88eb-0cdd707cd217"), "Carlos Vazquez Ricardez", "System", new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(7864), "", "rricardez@live.com.ar", true, false, new DateTime(2025, 9, 22, 5, 42, 47, 944, DateTimeKind.Utc).AddTicks(7866), "System", "$2a$11$Yloq8W/qjVYmyZsUpUOaUO.fWDLbsayFS1bKzVqgCtUzZYfCE1zN6", "admin" });
        }
    }
}
