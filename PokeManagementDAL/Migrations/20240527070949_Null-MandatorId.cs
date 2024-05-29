﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class NullMandatorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_MandatorId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "MandatorId",
                table: "Orders",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_MandatorId",
                table: "Orders",
                column: "MandatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_MandatorId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "MandatorId",
                table: "Orders",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_MandatorId",
                table: "Orders",
                column: "MandatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
