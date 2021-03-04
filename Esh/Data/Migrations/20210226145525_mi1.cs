using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esh.Data.Migrations
{
    public partial class mi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connection_Reqs",
                columns: table => new
                {
                    requestuser = table.Column<string>(nullable: true),
                    Recivername = table.Column<string>(nullable: true),
                    time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection_Reqs");
        }
    }
}
