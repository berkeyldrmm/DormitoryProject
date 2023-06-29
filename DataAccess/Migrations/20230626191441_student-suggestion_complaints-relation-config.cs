using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class studentsuggestion_complaintsrelationconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Suggestion_ComplanintId",
                table: "Suggestions_Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_Complaints_Suggestion_ComplanintId",
                table: "Suggestions_Complaints",
                column: "Suggestion_ComplanintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_Complaints_AspNetUsers_Suggestion_ComplanintId",
                table: "Suggestions_Complaints",
                column: "Suggestion_ComplanintId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_Complaints_AspNetUsers_Suggestion_ComplanintId",
                table: "Suggestions_Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Suggestions_Complaints_Suggestion_ComplanintId",
                table: "Suggestions_Complaints");

            migrationBuilder.DropColumn(
                name: "Suggestion_ComplanintId",
                table: "Suggestions_Complaints");
        }
    }
}
