using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoTodayAPI.Migrations
{
    public partial class SeedToDoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    DueTime = table.Column<DateTime>(nullable: true),
                    Assignee = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstimatedTimeToComplete = table.Column<string>(nullable: true),
                    DifficultyRating = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Assignee", "CreatedByUserId", "Description", "DifficultyRating", "DueTime", "EstimatedTimeToComplete", "StartTime", "Title" },
                values: new object[] { 1, "Matthew", null, "Get up on that ladder and clean out those filthy gutters!", 4, new DateTime(2020, 6, 17, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(3149), "2 hours", new DateTime(2020, 6, 10, 17, 3, 45, 963, DateTimeKind.Local).AddTicks(9613), "Clean Gutters" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Assignee", "CreatedByUserId", "Description", "DifficultyRating", "DueTime", "EstimatedTimeToComplete", "StartTime", "Title" },
                values: new object[] { 2, "Matthew", null, "Your plants are rootbound-- fix it!", 2, new DateTime(2020, 6, 17, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6547), "2 hours", new DateTime(2020, 6, 10, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6517), "Pot Plants" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Assignee", "CreatedByUserId", "Description", "DifficultyRating", "DueTime", "EstimatedTimeToComplete", "StartTime", "Title" },
                values: new object[] { 3, "Jessie", null, "The hard part is done. Now we just have to build and hang the panels.", 3, new DateTime(2020, 6, 17, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6604), "2 hours", new DateTime(2020, 6, 10, 17, 3, 45, 967, DateTimeKind.Local).AddTicks(6599), "Build the Fence" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
