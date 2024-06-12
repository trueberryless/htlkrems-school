using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DEBITORS",
                columns: table => new
                {
                    DEBITOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEBITORS", x => x.DEBITOR_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "E_LEGAL_FOUNDATIONS",
                columns: table => new
                {
                    LABEL = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_LEGAL_FOUNDATIONS", x => x.LABEL);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "E_PROJECT_STATES",
                columns: table => new
                {
                    Label = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_PROJECT_STATES", x => x.Label);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "E_SUBPROJECT_STATES",
                columns: table => new
                {
                    LABEL = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_SUBPROJECT_STATES", x => x.LABEL);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FACILITIES_ST",
                columns: table => new
                {
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACILITY_CODE = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACILITY_TITLE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACILITY_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACULTY_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITIES_ST", x => x.FACILITY_ID);
                    table.ForeignKey(
                        name: "FK_FACILITIES_ST_FACILITIES_ST_FACULTY_ID",
                        column: x => x.FACULTY_ID,
                        principalTable: "FACILITIES_ST",
                        principalColumn: "FACILITY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECTS_BT",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LEGAL_FOUNDATION = table.Column<string>(type: "varchar(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS_BT", x => x.PROJECT_ID);
                    table.ForeignKey(
                        name: "FK_PROJECTS_BT_E_LEGAL_FOUNDATIONS_LEGAL_FOUNDATION",
                        column: x => x.LEGAL_FOUNDATION,
                        principalTable: "E_LEGAL_FOUNDATIONS",
                        principalColumn: "LABEL",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MANAGEMENT_PROJECTS",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_END = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MANAGEMENT_DUTY = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANAGEMENT_PROJECTS", x => x.PROJECT_ID);
                    table.ForeignKey(
                        name: "FK_MANAGEMENT_PROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECT_DEBITORS_JT",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    DEBITOR_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<float>(type: "float", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_DEBITORS_JT", x => new { x.PROJECT_ID, x.DEBITOR_ID });
                    table.ForeignKey(
                        name: "FK_PROJECT_DEBITORS_JT_DEBITORS_DEBITOR_ID",
                        column: x => x.DEBITOR_ID,
                        principalTable: "DEBITORS",
                        principalColumn: "DEBITOR_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_DEBITORS_JT_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECT_FORERUNNERS_JT",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_FORERUNNERS_JT", x => new { x.PROJECT_ID, x.PARENT_ID });
                    table.ForeignKey(
                        name: "FK_PROJECT_FORERUNNERS_JT_PROJECTS_BT_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_FORERUNNERS_JT_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECT_HAS_STATES_JT",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    PROJECT_STATE = table.Column<string>(type: "varchar(12)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATE_CHANGED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_HAS_STATES_JT", x => new { x.PROJECT_ID, x.PROJECT_STATE, x.STATE_CHANGED_AT });
                    table.ForeignKey(
                        name: "FK_PROJECT_HAS_STATES_JT_E_PROJECT_STATES_PROJECT_STATE",
                        column: x => x.PROJECT_STATE,
                        principalTable: "E_PROJECT_STATES",
                        principalColumn: "Label",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_HAS_STATES_JT_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "REQUEST_FUNDING_PROJECTS",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    IS_SMALL_PROJECT = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_FUNDING_PROJECTS", x => x.PROJECT_ID);
                    table.ForeignKey(
                        name: "FK_REQUEST_FUNDING_PROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RESEARCH_FUNDING_PROJECTS",
                columns: table => new
                {
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    IS_EU_SPONSORED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_FFG_SPONSORED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_FWF_SPONSORED = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESEARCH_FUNDING_PROJECTS", x => x.PROJECT_ID);
                    table.ForeignKey(
                        name: "FK_RESEARCH_FUNDING_PROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SUBPROJECTS",
                columns: table => new
                {
                    SUBPROJECT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    APPLIED_RESEARCH = table.Column<int>(type: "int", nullable: false),
                    THEORETICAL_RESEARCH = table.Column<int>(type: "int", nullable: false),
                    FOCUS_RESEARCH = table.Column<int>(type: "int", nullable: false),
                    PROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    INSTITUTE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBPROJECTS", x => x.SUBPROJECT_ID);
                    table.ForeignKey(
                        name: "FK_SUBPROJECTS_FACILITIES_ST_INSTITUTE_ID",
                        column: x => x.INSTITUTE_ID,
                        principalTable: "FACILITIES_ST",
                        principalColumn: "FACILITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUBPROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SUBPROJECT_HAS_STATES_JT",
                columns: table => new
                {
                    SUBPROJECT_ID = table.Column<int>(type: "int", nullable: false),
                    SUBPROJECT_STATE = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATE_CHANGED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBPROJECT_HAS_STATES_JT", x => new { x.SUBPROJECT_ID, x.SUBPROJECT_STATE, x.STATE_CHANGED_AT });
                    table.ForeignKey(
                        name: "FK_SUBPROJECT_HAS_STATES_JT_E_SUBPROJECT_STATES_SUBPROJECT_STATE",
                        column: x => x.SUBPROJECT_STATE,
                        principalTable: "E_SUBPROJECT_STATES",
                        principalColumn: "LABEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUBPROJECT_HAS_STATES_JT_SUBPROJECTS_SUBPROJECT_ID",
                        column: x => x.SUBPROJECT_ID,
                        principalTable: "SUBPROJECTS",
                        principalColumn: "SUBPROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITIES_ST_FACULTY_ID",
                table: "FACILITIES_ST",
                column: "FACULTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_DEBITORS_JT_DEBITOR_ID",
                table: "PROJECT_DEBITORS_JT",
                column: "DEBITOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_FORERUNNERS_JT_PARENT_ID",
                table: "PROJECT_FORERUNNERS_JT",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_HAS_STATES_JT_PROJECT_STATE",
                table: "PROJECT_HAS_STATES_JT",
                column: "PROJECT_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_BT_LEGAL_FOUNDATION",
                table: "PROJECTS_BT",
                column: "LEGAL_FOUNDATION");

            migrationBuilder.CreateIndex(
                name: "IX_SUBPROJECT_HAS_STATES_JT_SUBPROJECT_STATE",
                table: "SUBPROJECT_HAS_STATES_JT",
                column: "SUBPROJECT_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_SUBPROJECTS_INSTITUTE_ID",
                table: "SUBPROJECTS",
                column: "INSTITUTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUBPROJECTS_PROJECT_ID",
                table: "SUBPROJECTS",
                column: "PROJECT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MANAGEMENT_PROJECTS");

            migrationBuilder.DropTable(
                name: "PROJECT_DEBITORS_JT");

            migrationBuilder.DropTable(
                name: "PROJECT_FORERUNNERS_JT");

            migrationBuilder.DropTable(
                name: "PROJECT_HAS_STATES_JT");

            migrationBuilder.DropTable(
                name: "REQUEST_FUNDING_PROJECTS");

            migrationBuilder.DropTable(
                name: "RESEARCH_FUNDING_PROJECTS");

            migrationBuilder.DropTable(
                name: "SUBPROJECT_HAS_STATES_JT");

            migrationBuilder.DropTable(
                name: "DEBITORS");

            migrationBuilder.DropTable(
                name: "E_PROJECT_STATES");

            migrationBuilder.DropTable(
                name: "E_SUBPROJECT_STATES");

            migrationBuilder.DropTable(
                name: "SUBPROJECTS");

            migrationBuilder.DropTable(
                name: "FACILITIES_ST");

            migrationBuilder.DropTable(
                name: "PROJECTS_BT");

            migrationBuilder.DropTable(
                name: "E_LEGAL_FOUNDATIONS");
        }
    }
}
