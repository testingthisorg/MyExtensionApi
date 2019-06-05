using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class addingfbappid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FbAppId",
                table: "AppUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FbAppId",
                table: "AppUsers");
        }
    }
}
