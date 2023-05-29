using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class peticomerapplicationsreject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RejectStatus",
                table: "PeticomerApplications",
                type: "bit",
                nullable: true,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectStatus",
                table: "PeticomerApplications");
        }
    }
}
