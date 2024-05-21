using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUDEK.Migrations
{
    /// <inheritdoc />
    public partial class Initx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseSemester",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseSemester",
                table: "Courses");
        }
    }
}
