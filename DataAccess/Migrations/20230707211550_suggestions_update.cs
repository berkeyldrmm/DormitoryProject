using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class suggestions_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_Complaints_AspNetUsers_Suggestion_ComplanintId",
                table: "Suggestions_Complaints");

            migrationBuilder.RenameColumn(
                name: "Suggestion_ComplanintId",
                table: "Suggestions_Complaints",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Suggestions_Complaints_Suggestion_ComplanintId",
                table: "Suggestions_Complaints",
                newName: "IX_Suggestions_Complaints_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_Complaints_AspNetUsers_StudentId",
                table: "Suggestions_Complaints",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_Complaints_AspNetUsers_StudentId",
                table: "Suggestions_Complaints");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Suggestions_Complaints",
                newName: "Suggestion_ComplanintId");

            migrationBuilder.RenameIndex(
                name: "IX_Suggestions_Complaints_StudentId",
                table: "Suggestions_Complaints",
                newName: "IX_Suggestions_Complaints_Suggestion_ComplanintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_Complaints_AspNetUsers_Suggestion_ComplanintId",
                table: "Suggestions_Complaints",
                column: "Suggestion_ComplanintId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
