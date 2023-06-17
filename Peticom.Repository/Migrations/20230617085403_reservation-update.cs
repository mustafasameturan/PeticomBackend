using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class reservationupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PeticomerId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeticomerId",
                table: "Reservations");
        }
    }
}
