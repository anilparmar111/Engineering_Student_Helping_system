using Microsoft.EntityFrameworkCore.Migrations;

namespace Esh.Data.Migrations
{
    public partial class in2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "requestuser",
                table: "Connection_Reqs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Recivername",
                table: "Connection_Reqs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connection_Reqs",
                table: "Connection_Reqs",
                columns: new[] { "Recivername", "requestuser" });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    uid = table.Column<string>(nullable: false),
                    fid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.fid, x.uid });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connection_Reqs",
                table: "Connection_Reqs");

            migrationBuilder.AlterColumn<string>(
                name: "requestuser",
                table: "Connection_Reqs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Recivername",
                table: "Connection_Reqs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
