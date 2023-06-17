using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peticom.Repository.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdId",
                table: "Ads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayCount = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAppId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserAppId",
                        column: x => x.UserAppId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AdId",
                table: "Ads",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AdId",
                table: "Reservations",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserAppId",
                table: "Reservations",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Ads_AdId",
                table: "Ads",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Ads_AdId",
                table: "Ads");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Ads_AdId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdId",
                table: "Ads");
        }
    }
}
