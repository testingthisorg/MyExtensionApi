using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__AdSetHistory_Campaigns_id",
                table: "_AdSetHistory");

            migrationBuilder.DropIndex(
                name: "IX__AdSetHistory_id",
                table: "_AdSetHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX__AdSetHistory_id",
                table: "_AdSetHistory",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__AdSetHistory_Campaigns_id",
                table: "_AdSetHistory",
                column: "id",
                principalTable: "Campaigns",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
