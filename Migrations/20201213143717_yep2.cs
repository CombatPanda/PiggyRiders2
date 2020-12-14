using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSaver.Migrations
{
    public partial class yep2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "add",
                table: "UserBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "remove",
                table: "UserBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "add",
                table: "UserBalance");

            migrationBuilder.DropColumn(
                name: "remove",
                table: "UserBalance");
        }
    }
}
