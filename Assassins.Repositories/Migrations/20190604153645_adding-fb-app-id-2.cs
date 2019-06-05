using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class addingfbappid2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FbAppId",
                table: "AppUsers",
                newName: "AdAssassinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdAssassinId",
                table: "AppUsers",
                newName: "FbAppId");
        }
    }
}
