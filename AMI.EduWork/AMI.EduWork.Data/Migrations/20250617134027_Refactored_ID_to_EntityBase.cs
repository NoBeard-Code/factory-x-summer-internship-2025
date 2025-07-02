using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMI.EduWork.Migrations
{
    /// <inheritdoc />
    public partial class Refactored_ID_to_EntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersOnVacations",
                table: "UsersOnVacations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersOnProjects",
                table: "UsersOnProjects");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UsersOnVacations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UsersOnProjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersOnVacations",
                table: "UsersOnVacations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersOnProjects",
                table: "UsersOnProjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnVacations_UserId",
                table: "UsersOnVacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnProjects_UserId",
                table: "UsersOnProjects",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersOnVacations",
                table: "UsersOnVacations");

            migrationBuilder.DropIndex(
                name: "IX_UsersOnVacations_UserId",
                table: "UsersOnVacations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersOnProjects",
                table: "UsersOnProjects");

            migrationBuilder.DropIndex(
                name: "IX_UsersOnProjects_UserId",
                table: "UsersOnProjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersOnVacations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersOnProjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersOnVacations",
                table: "UsersOnVacations",
                columns: new[] { "UserId", "AnnualVacationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersOnProjects",
                table: "UsersOnProjects",
                columns: new[] { "UserId", "ProjectId" });
        }
    }
}
