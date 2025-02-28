using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingGame.Migrations
{
    /// <inheritdoc />
    public partial class GameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_score",
                table: "Players",
                newName: "Player2Score");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "Player2Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayedAt",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Player1Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Player1Score",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayedAt",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Player1Name",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Player1Score",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Player2Score",
                table: "Players",
                newName: "_score");

            migrationBuilder.RenameColumn(
                name: "Player2Name",
                table: "Players",
                newName: "Name");
        }
    }
}
