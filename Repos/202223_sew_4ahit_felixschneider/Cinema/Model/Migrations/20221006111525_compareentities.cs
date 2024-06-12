using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class compareentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "STATE_CODE",
                table: "E_STATES",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "COUNTRY_NAME",
                table: "E_COUNTRIES",
                newName: "NAME");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "MOVIES",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "LONGTEXT")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "E_STATES",
                newName: "STATE_CODE");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "E_COUNTRIES",
                newName: "COUNTRY_NAME");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "MOVIES",
                type: "LONGTEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
