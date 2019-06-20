using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "owner",
                table: "AdAccounts",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<long>(
                name: "end_advertiser",
                table: "AdAccounts",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "AppUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "owner",
                table: "AdAccounts",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "end_advertiser",
                table: "AdAccounts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
