using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserDataSync_AppUsers_AppUserId",
                table: "AppUserDataSync");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserDataSync",
                table: "AppUserDataSync");

            migrationBuilder.RenameTable(
                name: "AppUserDataSync",
                newName: "AppUserDataSyncs");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserDataSync_AppUserId",
                table: "AppUserDataSyncs",
                newName: "IX_AppUserDataSyncs_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserDataSyncs",
                table: "AppUserDataSyncs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserDataSyncs_AppUsers_AppUserId",
                table: "AppUserDataSyncs",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserDataSyncs_AppUsers_AppUserId",
                table: "AppUserDataSyncs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserDataSyncs",
                table: "AppUserDataSyncs");

            migrationBuilder.RenameTable(
                name: "AppUserDataSyncs",
                newName: "AppUserDataSync");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserDataSyncs_AppUserId",
                table: "AppUserDataSync",
                newName: "IX_AppUserDataSync_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserDataSync",
                table: "AppUserDataSync",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserDataSync_AppUsers_AppUserId",
                table: "AppUserDataSync",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
