using Microsoft.EntityFrameworkCore.Migrations;

namespace CougNet.Migrations
{
    public partial class discusionboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CougProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    parentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    CougId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussions_Coug_CougId",
                        column: x => x.CougId,
                        principalTable: "Coug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discussions_CougProgram_CougProgramId",
                        column: x => x.CougProgramId,
                        principalTable: "CougProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_CougId",
                table: "Discussions",
                column: "CougId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_CougProgramId",
                table: "Discussions",
                column: "CougProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discussions");
        }
    }
}
