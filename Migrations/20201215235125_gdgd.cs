using Microsoft.EntityFrameworkCore.Migrations;

namespace Techno_Project.Migrations
{
    public partial class gdgd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovableItemsId",
                table: "FormData");

            migrationBuilder.AddColumn<int>(
                name: "FormDataid",
                table: "Movableitems",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormDataid",
                table: "Movableitems");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "FormEmail",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MovableItemsId",
                table: "FormData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
