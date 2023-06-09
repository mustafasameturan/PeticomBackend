using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class peticomerbadgefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PeticomerBadges",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PeticomerBadges_UserId",
                table: "PeticomerBadges",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PeticomerBadges_AspNetUsers_UserId",
                table: "PeticomerBadges",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeticomerBadges_AspNetUsers_UserId",
                table: "PeticomerBadges");

            migrationBuilder.DropIndex(
                name: "IX_PeticomerBadges_UserId",
                table: "PeticomerBadges");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PeticomerBadges",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
