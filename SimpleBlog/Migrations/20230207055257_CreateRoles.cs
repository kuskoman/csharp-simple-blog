using Microsoft.EntityFrameworkCore.Migrations;
using SimpleBlog.Models;

#nullable disable

namespace SimpleBlog.Migrations
{
    /// <inheritdoc />
    public partial class CreateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { (int)RoleEnum.User, "User", "USER" },
                    { (int)RoleEnum.Admin, "Admin", "ADMIN" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNewRoles",
                keyColumn: "Id",
                keyValue: RoleEnum.User
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: RoleEnum.Admin
            );
        }
    }
}
