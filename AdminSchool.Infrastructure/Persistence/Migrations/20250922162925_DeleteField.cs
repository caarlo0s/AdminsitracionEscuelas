using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminSchool.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Tutors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "StudentPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "StudentNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "SchoolYears",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "PaymentConcepts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "GroupSchools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "EducationLevels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "StudentPayments");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "StudentNotes");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "SchoolYears");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "PaymentConcepts");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "GroupSchools");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Documents");
        }
    }
}
