using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class LMSBookIssueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookIssues",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<int>(nullable: false),
                    PubId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssues", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_BookIssues_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookIssues_Publications_PubId",
                        column: x => x.PubId,
                        principalTable: "Publications",
                        principalColumn: "PubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_BranchId",
                table: "BookIssues",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_PubId",
                table: "BookIssues",
                column: "PubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookIssues");
        }
    }
}
