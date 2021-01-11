using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Techno_Project.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormData",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entryOrExit = table.Column<int>(type: "int", nullable: false),
                    enterOrExitDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vistorCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresntativeMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormData", x => x.FormId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormData");
        }
    }
}
