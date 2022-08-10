using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class addarole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoleId",
                table: "Students",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Roles_RoleId",
                table: "Students",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Roles_RoleId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Students");
        }
    }
}
