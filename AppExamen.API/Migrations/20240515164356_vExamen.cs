using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppExamen.API.Migrations
{
    /// <inheritdoc />
    public partial class vExamen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaFarmaceutica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AñoFundacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaFarmaceutica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmaco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipioActivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaFarmaceutica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmaco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmaco_MarcaFarmaceutica_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarcaFarmaceutica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmaco_MarcaId",
                table: "Farmaco",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmaco");

            migrationBuilder.DropTable(
                name: "MarcaFarmaceutica");
        }
    }
}
