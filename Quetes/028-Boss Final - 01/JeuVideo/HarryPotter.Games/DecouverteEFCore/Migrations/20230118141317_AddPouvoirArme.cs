using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecouverteEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddPouvoirArme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pouvoir",
                table: "Arme",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pouvoir",
                table: "Arme");
        }
    }
}
