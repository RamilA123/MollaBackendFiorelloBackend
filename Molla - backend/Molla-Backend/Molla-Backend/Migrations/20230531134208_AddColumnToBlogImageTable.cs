using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla_Backend.Migrations
{
    public partial class AddColumnToBlogImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "BlogImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BlogImages");
        }
    }
}
