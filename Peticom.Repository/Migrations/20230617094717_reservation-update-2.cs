using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class reservationupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCount",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayCount",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
