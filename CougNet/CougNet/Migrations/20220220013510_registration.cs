using Microsoft.EntityFrameworkCore.Migrations;

namespace CougNet.Migrations
{
    public partial class registration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CougProgramRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CougId = table.Column<int>(type: "INTEGER", nullable: true),
                    CougProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CougProgramRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CougProgramRegistrations_Coug_CougId",
                        column: x => x.CougId,
                        principalTable: "Coug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CougProgramRegistrations_CougProgram_CougProgramId",
                        column: x => x.CougProgramId,
                        principalTable: "CougProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CougProgramRegistrations_CougId",
                table: "CougProgramRegistrations",
                column: "CougId");

            migrationBuilder.CreateIndex(
                name: "IX_CougProgramRegistrations_CougProgramId",
                table: "CougProgramRegistrations",
                column: "CougProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CougProgramRegistrations");
        }
    }
}
