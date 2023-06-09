using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class peticomeridentityfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PetIdentities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PetIdentities_UserId",
                table: "PetIdentities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetIdentities_AspNetUsers_UserId",
                table: "PetIdentities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetIdentities_AspNetUsers_UserId",
                table: "PetIdentities");

            migrationBuilder.DropIndex(
                name: "IX_PetIdentities_UserId",
                table: "PetIdentities");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PetIdentities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
