using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerBackEnd5.Migrations
{
    public partial class InitialDR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceLimit",
                table: "PlanProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceLimit",
                table: "PlanProfiles");
        }
    }
}
