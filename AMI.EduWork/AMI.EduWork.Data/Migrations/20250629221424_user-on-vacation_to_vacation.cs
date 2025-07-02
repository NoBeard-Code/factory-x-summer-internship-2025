using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMI.EduWork.Migrations
{
    /// <inheritdoc />
    public partial class useronvacation_to_vacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersOnVacations");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnnualVacations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnnualVacationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_AnnualVacations_AnnualVacationId",
                        column: x => x.AnnualVacationId,
                        principalTable: "AnnualVacations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualVacations_UserId",
                table: "AnnualVacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_AnnualVacationId",
                table: "Vacations",
                column: "AnnualVacationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualVacations_AspNetUsers_UserId",
                table: "AnnualVacations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualVacations_AspNetUsers_UserId",
                table: "AnnualVacations");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_AnnualVacations_UserId",
                table: "AnnualVacations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnnualVacations");

            migrationBuilder.CreateTable(
                name: "UsersOnVacations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnnualVacationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOnVacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersOnVacations_AnnualVacations_AnnualVacationId",
                        column: x => x.AnnualVacationId,
                        principalTable: "AnnualVacations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersOnVacations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnVacations_AnnualVacationId",
                table: "UsersOnVacations",
                column: "AnnualVacationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnVacations_UserId",
                table: "UsersOnVacations",
                column: "UserId");
        }
    }
}
