using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddExecDateInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExecDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecDate",
                table: "Orders");
        }
    }
}
