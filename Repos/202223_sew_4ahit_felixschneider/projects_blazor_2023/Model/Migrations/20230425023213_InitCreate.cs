using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DEBITORS",
                columns: table => new
                {
                    DEBITORID = table.Column<int>(name: "DEBITOR_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEBITORS", x => x.DEBITORID);
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
                    FACILITYID = table.Column<int>(name: "FACILITY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACILITYCODE = table.Column<string>(name: "FACILITY_CODE", type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACILITYTITLE = table.Column<string>(name: "FACILITY_TITLE", type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACILITYTYPE = table.Column<string>(name: "FACILITY_TYPE", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACULTYID = table.Column<int>(name: "FACULTY_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITIES_ST", x => x.FACILITYID);
                    table.ForeignKey(
                        name: "FK_FACILITIES_ST_FACILITIES_ST_FACULTY_ID",
                        column: x => x.FACULTYID,
                        principalTable: "FACILITIES_ST",
                        principalColumn: "FACILITY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECTS_BT",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATEDAT = table.Column<DateTime>(name: "CREATED_AT", type: "datetime(6)", nullable: false),
                    LEGALFOUNDATION = table.Column<string>(name: "LEGAL_FOUNDATION", type: "varchar(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS_BT", x => x.PROJECTID);
                    table.ForeignKey(
                        name: "FK_PROJECTS_BT_E_LEGAL_FOUNDATIONS_LEGAL_FOUNDATION",
                        column: x => x.LEGALFOUNDATION,
                        principalTable: "E_LEGAL_FOUNDATIONS",
                        principalColumn: "LABEL",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MANAGEMENT_PROJECTS",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    PROJECTEND = table.Column<DateTime>(name: "PROJECT_END", type: "datetime(6)", nullable: false),
                    MANAGEMENTDUTY = table.Column<string>(name: "MANAGEMENT_DUTY", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANAGEMENT_PROJECTS", x => x.PROJECTID);
                    table.ForeignKey(
                        name: "FK_MANAGEMENT_PROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECT_DEBITORS_JT",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    DEBITORID = table.Column<int>(name: "DEBITOR_ID", type: "int", nullable: false),
                    AMOUNT = table.Column<float>(type: "float", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_DEBITORS_JT", x => new { x.PROJECTID, x.DEBITORID });
                    table.ForeignKey(
                        name: "FK_PROJECT_DEBITORS_JT_DEBITORS_DEBITOR_ID",
                        column: x => x.DEBITORID,
                        principalTable: "DEBITORS",
                        principalColumn: "DEBITOR_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_DEBITORS_JT_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECT_FORERUNNERS_JT",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    PARENTID = table.Column<int>(name: "PARENT_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_FORERUNNERS_JT", x => new { x.PROJECTID, x.PARENTID });
                    table.ForeignKey(
                        name: "FK_PROJECT_FORERUNNERS_JT_PROJECTS_BT_PARENT_ID",
                        column: x => x.PARENTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_FORERUNNERS_JT_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROJECT_HAS_STATES_JT",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    PROJECTSTATE = table.Column<string>(name: "PROJECT_STATE", type: "varchar(12)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATECHANGEDAT = table.Column<DateTime>(name: "STATE_CHANGED_AT", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_HAS_STATES_JT", x => new { x.PROJECTID, x.PROJECTSTATE, x.STATECHANGEDAT });
                    table.ForeignKey(
                        name: "FK_PROJECT_HAS_STATES_JT_E_PROJECT_STATES_PROJECT_STATE",
                        column: x => x.PROJECTSTATE,
                        principalTable: "E_PROJECT_STATES",
                        principalColumn: "Label",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_HAS_STATES_JT_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "REQUEST_FUNDING_PROJECTS",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    ISSMALLPROJECT = table.Column<bool>(name: "IS_SMALL_PROJECT", type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_FUNDING_PROJECTS", x => x.PROJECTID);
                    table.ForeignKey(
                        name: "FK_REQUEST_FUNDING_PROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RESEARCH_FUNDING_PROJECTS",
                columns: table => new
                {
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    ISEUSPONSORED = table.Column<bool>(name: "IS_EU_SPONSORED", type: "tinyint(1)", nullable: false),
                    ISFFGSPONSORED = table.Column<bool>(name: "IS_FFG_SPONSORED", type: "tinyint(1)", nullable: false),
                    ISFWFSPONSORED = table.Column<bool>(name: "IS_FWF_SPONSORED", type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESEARCH_FUNDING_PROJECTS", x => x.PROJECTID);
                    table.ForeignKey(
                        name: "FK_RESEARCH_FUNDING_PROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SUBPROJECTS",
                columns: table => new
                {
                    SUBPROJECTID = table.Column<int>(name: "SUBPROJECT_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    APPLIEDRESEARCH = table.Column<int>(name: "APPLIED_RESEARCH", type: "int", nullable: false),
                    THEORETICALRESEARCH = table.Column<int>(name: "THEORETICAL_RESEARCH", type: "int", nullable: false),
                    FOCUSRESEARCH = table.Column<int>(name: "FOCUS_RESEARCH", type: "int", nullable: false),
                    PROJECTID = table.Column<int>(name: "PROJECT_ID", type: "int", nullable: false),
                    INSTITUTEID = table.Column<int>(name: "INSTITUTE_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBPROJECTS", x => x.SUBPROJECTID);
                    table.ForeignKey(
                        name: "FK_SUBPROJECTS_FACILITIES_ST_INSTITUTE_ID",
                        column: x => x.INSTITUTEID,
                        principalTable: "FACILITIES_ST",
                        principalColumn: "FACILITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUBPROJECTS_PROJECTS_BT_PROJECT_ID",
                        column: x => x.PROJECTID,
                        principalTable: "PROJECTS_BT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SUBPROJECT_HAS_STATES_JT",
                columns: table => new
                {
                    SUBPROJECTID = table.Column<int>(name: "SUBPROJECT_ID", type: "int", nullable: false),
                    SUBPROJECTSTATE = table.Column<string>(name: "SUBPROJECT_STATE", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATECHANGEDAT = table.Column<DateTime>(name: "STATE_CHANGED_AT", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBPROJECT_HAS_STATES_JT", x => new { x.SUBPROJECTID, x.SUBPROJECTSTATE, x.STATECHANGEDAT });
                    table.ForeignKey(
                        name: "FK_SUBPROJECT_HAS_STATES_JT_E_SUBPROJECT_STATES_SUBPROJECT_STATE",
                        column: x => x.SUBPROJECTSTATE,
                        principalTable: "E_SUBPROJECT_STATES",
                        principalColumn: "LABEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUBPROJECT_HAS_STATES_JT_SUBPROJECTS_SUBPROJECT_ID",
                        column: x => x.SUBPROJECTID,
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

        /// <inheritdoc />
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
