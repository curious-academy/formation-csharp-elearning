using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecouverteEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddPointsVieEnemy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsDeVie",
                table: "Ennemi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsDeVie",
                table: "Ennemi");
        }
    }
}
