using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_Final.Migrations
{
    public partial class LC0102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Automobiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Automobiles");
        }
    }
}
