using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUDEK.Migrations
{
    /// <inheritdoc />
    public partial class Inital33kj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltBasliks");

            migrationBuilder.AlterColumn<string>(
                name: "DegerlendirmeYuzde",
                table: "Degerlendirmeler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DegerlendirmeAltBaslik",
                table: "Degerlendirmeler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DegerlendirmeYuzde",
                table: "Degerlendirmeler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DegerlendirmeAltBaslik",
                table: "Degerlendirmeler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AltBasliks",
                columns: table => new
                {
                    AltBaslikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegerlendirmeId = table.Column<int>(type: "int", nullable: false),
                    AltBasliklar = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
