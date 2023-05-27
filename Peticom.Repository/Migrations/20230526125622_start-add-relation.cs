using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class startaddrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stars_AdId",
                table: "Stars",
                column: "AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_Ads_AdId",
                table: "Stars",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stars_Ads_AdId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Stars_AdId",
                table: "Stars");
        }
    }
}
