using Microsoft.EntityFrameworkCore.Migrations;

namespace Esh.Data.Migrations
{
    public partial class done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.CreateTable(
                name: "EshUsers",
                columns: table => new
                {
                    EshUserUserId = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    Persnal_Site_URL = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: false),
                    about = table.Column<string>(nullable: true),
                    gender = table.Column<bool>(nullable: false),
                    Schoolname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EshUsers", x => x.EshUserUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EshUsers");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persnal_Site_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }
    }
}
