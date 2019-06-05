using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarUrl = table.Column<string>(nullable: true),
                    ExternalId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsSuspended = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => new { x.AppUserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Assassins Club Free" },
                    { 3, "Assassins Club Premium" },
                    { 4, "Assassins Club Platinum" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "AvatarUrl", "CreatedBy", "CreatedById", "CreatedOn", "Email", "ExternalId", "FirstName", "IsDeleted", "IsSuspended", "LastName", "ModifiedBy", "ModifiedById", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "http://free-icon-rainbow.com/i/icon_04062/icon_040629_64.png", "joe.jordan@assassinsclub.com", 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@assassinsclub.com", "8BNz8FqTVGVjYyXudC6DSZkpiws1", "System", false, false, "Bot", "joe.jordan@assassinsclub.com", 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "https://i0.wp.com/cdn.auth0.com/avatars/dj.png?ssl=1", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe.jordan@outlook.com", "lv9iYbUYKdRQ0i700sVt9ZjVFps1", "Joe", false, false, "Jordan", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppRoles");
        }
    }
}
