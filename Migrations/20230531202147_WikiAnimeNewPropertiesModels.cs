using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiAnime.Migrations
{
    /// <inheritdoc />
    public partial class WikiAnimeNewPropertiesModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Personajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Portada",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Portada",
                table: "Animes");
        }
    }
}
