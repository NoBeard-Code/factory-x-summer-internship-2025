using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMI.EduWork.Migrations
{
    /// <inheritdoc />
    public partial class Changed_relation_with_WorkDay_User_TimeSlice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlices_Projects_ProjectId",
                table: "TimeSlices");

            migrationBuilder.DropTable(
                name: "ApplicationUserWorkDay");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "TimeSlices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TimeSlices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Role",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlices_UserId",
                table: "TimeSlices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlices_AspNetUsers_UserId",
                table: "TimeSlices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlices_Projects_ProjectId",
                table: "TimeSlices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlices_AspNetUsers_UserId",
                table: "TimeSlices");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlices_Projects_ProjectId",
                table: "TimeSlices");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlices_UserId",
                table: "TimeSlices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TimeSlices");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "TimeSlices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserWorkDay",
                columns: table => new
                {
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkDaysId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserWorkDay", x => new { x.UsersId, x.WorkDaysId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserWorkDay_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserWorkDay_WorkDays_WorkDaysId",
                        column: x => x.WorkDaysId,
                        principalTable: "WorkDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserWorkDay_WorkDaysId",
                table: "ApplicationUserWorkDay",
                column: "WorkDaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlices_Projects_ProjectId",
                table: "TimeSlices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
