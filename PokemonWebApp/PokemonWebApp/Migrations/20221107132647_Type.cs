using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonWebApp.Migrations
{
    public partial class Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Pokedex",
                newName: "Types");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Types",
                table: "Pokedex",
                newName: "Type");
        }
    }
}
