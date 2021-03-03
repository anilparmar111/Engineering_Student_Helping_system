using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esh.Data.Migrations
{
    public partial class _36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AlterColumn<string>(
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

            migrationBuilder.CreateTable(
                name: "postDatas",
                columns: table => new
                {
                    postid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    richtext_file_path = table.Column<string>(nullable: true),
                    uploadtime = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    uid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postDatas", x => x.postid);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "postDatas");

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
