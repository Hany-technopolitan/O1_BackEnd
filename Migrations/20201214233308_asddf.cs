using Microsoft.EntityFrameworkCore.Migrations;

namespace Techno_Project.Migrations
{
    public partial class asddf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovableItemsId",
                table: "FormData",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovableItemsId",
                table: "FormData");
        }
    }
}
