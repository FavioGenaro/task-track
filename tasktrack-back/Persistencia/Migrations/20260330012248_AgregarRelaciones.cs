using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistory_TaskId",
                table: "TaskHistory",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsTask_TaskId",
                table: "TagsTask",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsTask_Tags_TagId",
                table: "TagsTask",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsTask_Tasks_TaskId",
                table: "TagsTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistory_Tasks_TaskId",
                table: "TaskHistory",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_User_UserId",
                table: "UserPreferences",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsTask_Tags_TagId",
                table: "TagsTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TagsTask_Tasks_TaskId",
                table: "TagsTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistory_Tasks_TaskId",
                table: "TaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_User_UserId",
                table: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskHistory_TaskId",
                table: "TaskHistory");

            migrationBuilder.DropIndex(
                name: "IX_TagsTask_TaskId",
                table: "TagsTask");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
