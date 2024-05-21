using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUDEK.Migrations
{
    /// <inheritdoc />
    public partial class Initnmx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AltBasliks",
                columns: table => new
                {
                    AltBaslikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltBasliklar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegerlendirmeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltBasliks", x => x.AltBaslikId);
                    table.ForeignKey(
                        name: "FK_AltBasliks_Degerlendirmeler_DegerlendirmeId",
                        column: x => x.DegerlendirmeId,
                        principalTable: "Degerlendirmeler",
                        principalColumn: "DegerlendirmeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltBasliks_DegerlendirmeId",
                table: "AltBasliks",
                column: "DegerlendirmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltBasliks");
        }
    }
}
