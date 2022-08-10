using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class LMSBookMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Detail = table.Column<string>(type: "varchar(200)", nullable: true),
                    Author = table.Column<string>(type: "varchar(100)", nullable: false),
                    PubId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BookPhoto = table.Column<string>(type: "varchar(300)", nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publications_PubId",
                        column: x => x.PubId,
                        principalTable: "Publications",
                        principalColumn: "PubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BranchId",
                table: "Books",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PubId",
                table: "Books",
                column: "PubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
