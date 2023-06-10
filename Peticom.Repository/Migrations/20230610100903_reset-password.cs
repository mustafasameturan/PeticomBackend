using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class resetpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordVerificationCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordVerificationCode",
                table: "AspNetUsers");
        }
    }
}
