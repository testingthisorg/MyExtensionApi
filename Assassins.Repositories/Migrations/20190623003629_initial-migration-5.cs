using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdImagesCompleted",
                table: "AppUserDataSyncs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AdInsightsCompleted",
                table: "AppUserDataSyncs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdImagesCompleted",
                table: "AppUserDataSyncs");

            migrationBuilder.DropColumn(
                name: "AdInsightsCompleted",
                table: "AppUserDataSyncs");
        }
    }
}
