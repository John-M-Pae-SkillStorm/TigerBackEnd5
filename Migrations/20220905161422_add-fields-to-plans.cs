using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerBackEnd5.Migrations
{
    public partial class addfieldstoplans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceLimit",
                table: "PlanProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "PlanProfiles",
                columns: new[] { "Id", "DeviceLimit", "PlanName", "PlanPrice" },
                values: new object[] { 1, 4, "Cub", 10 });

            migrationBuilder.InsertData(
                table: "PlanProfiles",
                columns: new[] { "Id", "DeviceLimit", "PlanName", "PlanPrice" },
                values: new object[] { 2, 8, "Leopard", 20 });

            migrationBuilder.InsertData(
                table: "PlanProfiles",
                columns: new[] { "Id", "DeviceLimit", "PlanName", "PlanPrice" },
                values: new object[] { 3, 12, "Tiger", 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlanProfiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DeviceLimit",
                table: "PlanProfiles");
        }
    }
}
