using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CREATURES",
                columns: table => new
                {
                    CREATURE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BODY = table.Column<int>(type: "int", nullable: false),
                    MIND = table.Column<int>(type: "int", nullable: false),
                    SOUL = table.Column<int>(type: "int", nullable: false),
                    ARMOUR = table.Column<int>(type: "int", nullable: false),
                    TOUGNESS = table.Column<int>(type: "int", nullable: false),
                    WOUNDS = table.Column<int>(type: "int", nullable: false),
                    METTLE = table.Column<int>(type: "int", nullable: false),
                    INITIATIVE = table.Column<int>(type: "int", nullable: false),
                    AWARENESS = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREATURES", x => x.CREATURE_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SKILLS",
                columns: table => new
                {
                    SKILL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDENTIFIER = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SKILL_VALUE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKILLS", x => x.SKILL_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRAITS",
                columns: table => new
                {
                    TRAIT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDENTIFIER = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAITS", x => x.TRAIT_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ATTACKS",
                columns: table => new
                {
                    ATTACK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDENTIFIER = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ATTACK_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DAMAGE = table.Column<int>(type: "int", nullable: false),
                    CREATURE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACKS", x => x.ATTACK_ID);
                    table.ForeignKey(
                        name: "FK_ATTACKS_CREATURES_CREATURE_ID",
                        column: x => x.CREATURE_ID,
                        principalTable: "CREATURES",
                        principalColumn: "CREATURE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CREATURE_HAS_SKILLS_JT",
                columns: table => new
                {
                    CREATURE_ID = table.Column<int>(type: "int", nullable: false),
                    SKILL_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREATURE_HAS_SKILLS_JT", x => new { x.CREATURE_ID, x.SKILL_ID });
                    table.ForeignKey(
                        name: "FK_CREATURE_HAS_SKILLS_JT_CREATURES_CREATURE_ID",
                        column: x => x.CREATURE_ID,
                        principalTable: "CREATURES",
                        principalColumn: "CREATURE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CREATURE_HAS_SKILLS_JT_SKILLS_SKILL_ID",
                        column: x => x.SKILL_ID,
                        principalTable: "SKILLS",
                        principalColumn: "SKILL_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CREATURE_HAS_TRAITS_JT",
                columns: table => new
                {
                    CREATURE_ID = table.Column<int>(type: "int", nullable: false),
                    TRAIT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREATURE_HAS_TRAITS_JT", x => new { x.CREATURE_ID, x.TRAIT_ID });
                    table.ForeignKey(
                        name: "FK_CREATURE_HAS_TRAITS_JT_CREATURES_CREATURE_ID",
                        column: x => x.CREATURE_ID,
                        principalTable: "CREATURES",
                        principalColumn: "CREATURE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CREATURE_HAS_TRAITS_JT_TRAITS_TRAIT_ID",
                        column: x => x.TRAIT_ID,
                        principalTable: "TRAITS",
                        principalColumn: "TRAIT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ATTACKS_CREATURE_ID",
                table: "ATTACKS",
                column: "CREATURE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ATTACKS_IDENTIFIER",
                table: "ATTACKS",
                column: "IDENTIFIER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CREATURE_HAS_SKILLS_JT_SKILL_ID",
                table: "CREATURE_HAS_SKILLS_JT",
                column: "SKILL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CREATURE_HAS_TRAITS_JT_TRAIT_ID",
                table: "CREATURE_HAS_TRAITS_JT",
                column: "TRAIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CREATURES_NAME",
                table: "CREATURES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SKILLS_IDENTIFIER",
                table: "SKILLS",
                column: "IDENTIFIER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRAITS_IDENTIFIER",
                table: "TRAITS",
                column: "IDENTIFIER",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTACKS");

            migrationBuilder.DropTable(
                name: "CREATURE_HAS_SKILLS_JT");

            migrationBuilder.DropTable(
                name: "CREATURE_HAS_TRAITS_JT");

            migrationBuilder.DropTable(
                name: "SKILLS");

            migrationBuilder.DropTable(
                name: "CREATURES");

            migrationBuilder.DropTable(
                name: "TRAITS");
        }
    }
}
