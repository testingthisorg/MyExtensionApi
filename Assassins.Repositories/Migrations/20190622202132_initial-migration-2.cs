using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "RecordDate",
                table: "Campaigns");

            migrationBuilder.AddColumn<long>(
                name: "_GeolocationHistoryItemAppUserDataSyncId",
                table: "GeolocationRegionMaps",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "_GeolocationHistoryItemadset_id",
                table: "GeolocationRegionMaps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeolocationRegionMaps__GeolocationHistoryItemAppUserDataSyncId__GeolocationHistoryItemadset_id",
                table: "GeolocationRegionMaps",
                columns: new[] { "_GeolocationHistoryItemAppUserDataSyncId", "_GeolocationHistoryItemadset_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_GeolocationRegionMaps__GeolocationHistory__GeolocationHistoryItemAppUserDataSyncId__GeolocationHistoryItemadset_id",
                table: "GeolocationRegionMaps",
                columns: new[] { "_GeolocationHistoryItemAppUserDataSyncId", "_GeolocationHistoryItemadset_id" },
                principalTable: "_GeolocationHistory",
                principalColumns: new[] { "AppUserDataSyncId", "adset_id" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeolocationRegionMaps__GeolocationHistory__GeolocationHistoryItemAppUserDataSyncId__GeolocationHistoryItemadset_id",
                table: "GeolocationRegionMaps");

            migrationBuilder.DropIndex(
                name: "IX_GeolocationRegionMaps__GeolocationHistoryItemAppUserDataSyncId__GeolocationHistoryItemadset_id",
                table: "GeolocationRegionMaps");

            migrationBuilder.DropColumn(
                name: "_GeolocationHistoryItemAppUserDataSyncId",
                table: "GeolocationRegionMaps");

            migrationBuilder.DropColumn(
                name: "_GeolocationHistoryItemadset_id",
                table: "GeolocationRegionMaps");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Campaigns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordDate",
                table: "Campaigns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
