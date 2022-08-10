using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class Penalties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    PenaltyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    PublicationName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    PenaltyAmount = table.Column<decimal>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    BookName = table.Column<string>(nullable: true),
                    BookPhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.PenaltyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penalties");
        }
    }
}
