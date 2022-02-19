using Microsoft.EntityFrameworkCore.Migrations;

namespace CougNet.Migrations
{
    public partial class Coug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coug",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    YearId = table.Column<int>(type: "INTEGER", nullable: true),
                    MajorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coug_CougCourse_MajorId",
                        column: x => x.MajorId,
                        principalTable: "CougCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coug_CougYear_YearId",
                        column: x => x.YearId,
                        principalTable: "CougYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coug_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coug_GenderId",
                table: "Coug",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Coug_MajorId",
                table: "Coug",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Coug_YearId",
                table: "Coug",
                column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coug");
        }
    }
}
