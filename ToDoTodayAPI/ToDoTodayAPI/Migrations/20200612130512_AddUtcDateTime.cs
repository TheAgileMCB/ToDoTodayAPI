using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoTodayAPI.Migrations
{
    public partial class AddUtcDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DueTime", "StartTime" },
                values: new object[] { new DateTime(2020, 6, 19, 13, 5, 11, 556, DateTimeKind.Utc).AddTicks(6273), new DateTime(2020, 6, 12, 13, 5, 11, 556, DateTimeKind.Utc).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DueTime", "StartTime" },
                values: new object[] { new DateTime(2020, 6, 19, 13, 5, 11, 556, DateTimeKind.Utc).AddTicks(9414), new DateTime(2020, 6, 12, 13, 5, 11, 556, DateTimeKind.Utc).AddTicks(9398) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DueTime", "StartTime" },
                values: new object[] { new DateTime(2020, 6, 19, 13, 5, 11, 556, DateTimeKind.Utc).AddTicks(9471), new DateTime(2020, 6, 12, 13, 5, 11, 556, DateTimeKind.Utc).AddTicks(9470) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DueTime", "StartTime" },
                values: new object[] { new DateTime(2020, 6, 17, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(3149), new DateTime(2020, 6, 10, 17, 3, 45, 963, DateTimeKind.Local).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DueTime", "StartTime" },
                values: new object[] { new DateTime(2020, 6, 17, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6547), new DateTime(2020, 6, 10, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DueTime", "StartTime" },
                values: new object[] { new DateTime(2020, 6, 17, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6604), new DateTime(2020, 6, 10, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6599) });
        }
    }
}
