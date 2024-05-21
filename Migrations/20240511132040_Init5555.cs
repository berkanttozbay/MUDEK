using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUDEK.Migrations
{
    /// <inheritdoc />
    public partial class Init5555 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degerlendirmeler",
                columns: table => new
                {
                    DegerlendirmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegerlendirmeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegerlendirmeYuzde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DegerlendirmeAltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degerlendirmeler", x => x.DegerlendirmeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degerlendirmeler");
        }
    }
}
