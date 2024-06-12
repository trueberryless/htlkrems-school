using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class addentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "E_COUNTRIES",
                columns: table => new
                {
                    COUNTRY_NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_COUNTRIES", x => x.COUNTRY_NAME);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "E_STATES",
                columns: table => new
                {
                    STATE_CODE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_STATES", x => x.STATE_CODE);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MOVIE_CREWS",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIE_CREWS", x => x.PERSON_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MOVIES",
                columns: table => new
                {
                    MOVIE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DURATION = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "LONGTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHORT_DESCRIPTION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIES", x => x.MOVIE_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    POSTAL_CODE = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOCATION = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STREET = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COUNTRY = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATE = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_E_COUNTRIES_COUNTRY",
                        column: x => x.COUNTRY,
                        principalTable: "E_COUNTRIES",
                        principalColumn: "COUNTRY_NAME",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_E_STATES_STATE",
                        column: x => x.STATE,
                        principalTable: "E_STATES",
                        principalColumn: "STATE_CODE",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OCCUPATIONS_JT",
                columns: table => new
                {
                    MOVIE_ID = table.Column<int>(type: "int", nullable: false),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OCCUPATION_BEGIN = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    OCCUPATION_END = table.Column<DateTime>(type: "DATETIME(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCCUPATIONS_JT", x => new { x.MOVIE_ID, x.PERSON_ID, x.ROLE, x.OCCUPATION_BEGIN });
                    table.ForeignKey(
                        name: "FK_OCCUPATIONS_JT_MOVIE_CREWS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "MOVIE_CREWS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OCCUPATIONS_JT_MOVIES_MOVIE_ID",
                        column: x => x.MOVIE_ID,
                        principalTable: "MOVIES",
                        principalColumn: "MOVIE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CINEMAS",
                columns: table => new
                {
                    CINEMA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LABEL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CINEMAS", x => x.CINEMA_ID);
                    table.ForeignKey(
                        name: "FK_CINEMAS_ADDRESSES_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalTable: "ADDRESSES",
                        principalColumn: "ADDRESS_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HALLS",
                columns: table => new
                {
                    HALL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CAPACITY = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CINEMA_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HALLS", x => x.HALL_ID);
                    table.ForeignKey(
                        name: "FK_HALLS_CINEMAS_CINEMA_ID",
                        column: x => x.CINEMA_ID,
                        principalTable: "CINEMAS",
                        principalColumn: "CINEMA_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SCREENINGS_JT",
                columns: table => new
                {
                    MOVIE_ID = table.Column<int>(type: "int", nullable: false),
                    HALL_ID = table.Column<int>(type: "int", nullable: false),
                    STARTS_AT = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    ENDS_AT = table.Column<DateTime>(type: "DATETIME(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCREENINGS_JT", x => new { x.MOVIE_ID, x.HALL_ID, x.STARTS_AT });
                    table.ForeignKey(
                        name: "FK_SCREENINGS_JT_HALLS_HALL_ID",
                        column: x => x.HALL_ID,
                        principalTable: "HALLS",
                        principalColumn: "HALL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCREENINGS_JT_MOVIES_MOVIE_ID",
                        column: x => x.MOVIE_ID,
                        principalTable: "MOVIES",
                        principalColumn: "MOVIE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_COUNTRY",
                table: "ADDRESSES",
                column: "COUNTRY");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_STATE",
                table: "ADDRESSES",
                column: "STATE");

            migrationBuilder.CreateIndex(
                name: "IX_CINEMAS_ADDRESS_ID",
                table: "CINEMAS",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HALLS_CINEMA_ID",
                table: "HALLS",
                column: "CINEMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OCCUPATIONS_JT_PERSON_ID",
                table: "OCCUPATIONS_JT",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCREENINGS_JT_HALL_ID",
                table: "SCREENINGS_JT",
                column: "HALL_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OCCUPATIONS_JT");

            migrationBuilder.DropTable(
                name: "SCREENINGS_JT");

            migrationBuilder.DropTable(
                name: "MOVIE_CREWS");

            migrationBuilder.DropTable(
                name: "HALLS");

            migrationBuilder.DropTable(
                name: "MOVIES");

            migrationBuilder.DropTable(
                name: "CINEMAS");

            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "E_COUNTRIES");

            migrationBuilder.DropTable(
                name: "E_STATES");
        }
    }
}
