using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrentEloRanking = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfDuelsWon = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfDuelsLost = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfDuelsDraw = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfDuelsPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageDuelDuration = table.Column<double>(type: "REAL", nullable: false),
                    LastDuelPlayedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYERS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLAYERS");
        }
    }
}
