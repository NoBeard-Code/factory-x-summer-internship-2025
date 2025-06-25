using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMI.EduWork._2025.Migrations
{
    /// <inheritdoc />
    public partial class Added_description_attribute_to_TimeSlice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TimeSlices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TimeSlices");
        }
    }
}
