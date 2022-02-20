using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CougNet.Migrations
{
    public partial class dicsso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostDateTime",
                table: "Discussions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDateTime",
                table: "Discussions");
        }
    }
}
