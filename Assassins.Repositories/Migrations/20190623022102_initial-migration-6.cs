using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdImages_account_id",
                table: "AdImages",
                column: "account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdImages_AdAccounts_account_id",
                table: "AdImages",
                column: "account_id",
                principalTable: "AdAccounts",
                principalColumn: "account_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdImages_AdAccounts_account_id",
                table: "AdImages");

            migrationBuilder.DropIndex(
                name: "IX_AdImages_account_id",
                table: "AdImages");
        }
    }
}
