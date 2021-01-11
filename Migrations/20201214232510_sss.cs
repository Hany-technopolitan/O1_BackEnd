using Microsoft.EntityFrameworkCore.Migrations;

namespace Techno_Project.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "serialNumber",
                table: "FormData",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serialNumber",
                table: "FormData");

        }
    }
}
