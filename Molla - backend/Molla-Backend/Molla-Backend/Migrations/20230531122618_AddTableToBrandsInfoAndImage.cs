using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla_Backend.Migrations
{
    public partial class AddTableToBrandsInfoAndImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "BrandsInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "BrandsImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BrandsInfos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BrandsImages");
        }
    }
}
