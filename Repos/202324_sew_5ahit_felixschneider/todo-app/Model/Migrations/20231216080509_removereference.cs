using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class removereference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TODOS",
                columns: table => new
                {
                    TODOID = table.Column<int>(name: "TODO_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false),
                    COMPLETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODOS", x => x.TODOID);
                    table.ForeignKey(
                        name: "FK_TODOS_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TODOS_USER_ID",
                table: "TODOS",
                column: "USER_ID");
        }
    }
}
