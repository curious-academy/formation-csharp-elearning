using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecouverteEFCore.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arme",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dommages = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ennemi",
                columns: table => new
                {
                    Prenom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArmeId = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ennemi", x => x.Prenom);
                    table.ForeignKey(
                        name: "FK_Ennemi_Arme_ArmeId",
                        column: x => x.ArmeId,
                        principalTable: "Arme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ennemi_ArmeId",
                table: "Ennemi",
                column: "ArmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ennemi");

            migrationBuilder.DropTable(
                name: "Arme");
        }
    }
}
