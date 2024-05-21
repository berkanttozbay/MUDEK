using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUDEK.Migrations
{
    /// <inheritdoc />
    public partial class Initewwk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Degerlendirmeler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_CourseId",
                table: "Degerlendirmeler",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degerlendirmeler_Courses_CourseId",
                table: "Degerlendirmeler",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degerlendirmeler_Courses_CourseId",
                table: "Degerlendirmeler");

            migrationBuilder.DropIndex(
                name: "IX_Degerlendirmeler_CourseId",
                table: "Degerlendirmeler");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Degerlendirmeler");
        }
    }
}
