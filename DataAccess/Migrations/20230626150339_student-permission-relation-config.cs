using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class studentpermissionrelationconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_StudentId",
                table: "Permissions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetUsers_StudentId",
                table: "Permissions",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetUsers_StudentId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_StudentId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Permissions");
        }
    }
}
