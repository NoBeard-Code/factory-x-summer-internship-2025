using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMI.EduWork._2025.Migrations
{
    /// <inheritdoc />
    public partial class contract_created_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Created",
                table: "Contracts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Contracts");
        }
    }
}
