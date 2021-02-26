using Microsoft.EntityFrameworkCore.Migrations;

namespace Esh.Data.Migrations
{
    public partial class fd5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "emailid",
                table: "Eusers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailid",
                table: "Eusers");
        }
    }
}
