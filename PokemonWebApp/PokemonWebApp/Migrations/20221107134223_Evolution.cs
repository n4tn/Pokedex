using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonWebApp.Migrations
{
    public partial class Evolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Evolution",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evolution",
                table: "Pokedex");
        }
    }
}
