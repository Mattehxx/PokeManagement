using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class SyntaxFixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Allegergen",
                table: "Ingredients",
                newName: "Allergen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Allergen",
                table: "Ingredients",
                newName: "Allegergen");
        }
    }
}
