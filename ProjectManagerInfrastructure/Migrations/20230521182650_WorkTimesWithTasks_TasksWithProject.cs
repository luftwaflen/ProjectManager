using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkTimesWithTasks_TasksWithProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_TaskId",
                table: "WorkTimes");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_TaskId",
                table: "WorkTimes",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_TaskId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_TaskId",
                table: "WorkTimes",
                column: "TaskId",
                unique: true);
        }
    }
}
