using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esh.Data.Migrations
{
    public partial class iweurhfuer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postDatas");
        }
    }
}
