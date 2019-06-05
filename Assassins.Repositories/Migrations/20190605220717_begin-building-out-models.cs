using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class beginbuildingoutmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRole_AppUsers_AppUserId",
                table: "AppUserRole");

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    action_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.AaId);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id = table.Column<decimal>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.AaId);
                });

            migrationBuilder.CreateTable(
                name: "AdAccounts",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    amount_spent = table.Column<long>(nullable: false),
                    account_status = table.Column<int>(nullable: false),
                    age = table.Column<double>(nullable: false),
                    balance = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    account_id = table.Column<decimal>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    business_city = table.Column<string>(nullable: true),
                    business_country_code = table.Column<string>(nullable: true),
                    business_name = table.Column<string>(nullable: true),
                    business_street = table.Column<string>(nullable: true),
                    business_street2 = table.Column<string>(nullable: true),
                    created_time = table.Column<DateTime>(nullable: false),
                    currency = table.Column<string>(nullable: true),
                    disable_reason = table.Column<int>(nullable: false),
                    end_advertiser = table.Column<decimal>(nullable: false),
                    end_advertiser_name = table.Column<string>(nullable: true),
                    fb_entity = table.Column<int>(nullable: false),
                    min_campaign_group_spend_cap = table.Column<int>(nullable: false),
                    min_daily_budget = table.Column<int>(nullable: false),
                    owner = table.Column<decimal>(nullable: false),
                    spend_cap = table.Column<int>(nullable: false),
                    timezone_id = table.Column<int>(nullable: false),
                    timezone_name = table.Column<string>(nullable: true),
                    timezone_offset_hours_utc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdAccounts", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_AdAccounts_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdAccounts_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributionSpecs",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    event_type = table.Column<string>(nullable: true),
                    window_days = table.Column<int>(nullable: false),
                    AdAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributionSpecs", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_AttributionSpecs_AdAccounts_AdAccountId",
                        column: x => x.AdAccountId,
                        principalTable: "AdAccounts",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    AdAccountId = table.Column<int>(nullable: false),
                    account_id = table.Column<decimal>(nullable: false),
                    budget_rebalance_flag = table.Column<bool>(nullable: false),
                    budget_remaining = table.Column<int>(nullable: false),
                    buying_type = table.Column<string>(nullable: true),
                    can_create_brand_lift_study = table.Column<bool>(nullable: false),
                    can_use_spend_cap = table.Column<bool>(nullable: false),
                    configured_status = table.Column<string>(nullable: true),
                    created_time = table.Column<DateTime>(nullable: false),
                    effective_status = table.Column<string>(nullable: true),
                    id = table.Column<decimal>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    objective = table.Column<string>(nullable: true),
                    source_campaign_id = table.Column<decimal>(nullable: false),
                    start_time = table.Column<DateTime>(nullable: false),
                    stop_time = table.Column<DateTime>(nullable: true),
                    updated_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_Campaigns_AdAccounts_AdAccountId",
                        column: x => x.AdAccountId,
                        principalTable: "AdAccounts",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdSets",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSets", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_AdSets_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignInsights",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(nullable: false),
                    buying_type = table.Column<string>(nullable: true),
                    clicks = table.Column<int>(nullable: false),
                    cost_per_inline_link_click = table.Column<double>(nullable: false),
                    cost_per_inline_post_engagement = table.Column<double>(nullable: false),
                    cost_per_unique_click = table.Column<double>(nullable: false),
                    cost_per_unique_inline_link_click = table.Column<double>(nullable: false),
                    cpc = table.Column<double>(nullable: false),
                    cpp = table.Column<double>(nullable: false),
                    ctr = table.Column<double>(nullable: false),
                    date_start = table.Column<DateTime>(nullable: false),
                    cpm = table.Column<double>(nullable: false),
                    date_stop = table.Column<DateTime>(nullable: false),
                    frequency = table.Column<double>(nullable: false),
                    impressions = table.Column<long>(nullable: false),
                    inline_link_click_ctr = table.Column<double>(nullable: false),
                    inline_link_clicks = table.Column<long>(nullable: false),
                    inline_post_engagement = table.Column<long>(nullable: false),
                    instant_experience_clicks_to_open = table.Column<long>(nullable: false),
                    instant_experience_clicks_to_start = table.Column<long>(nullable: false),
                    instant_experience_outbound_clicks = table.Column<long>(nullable: false),
                    reach = table.Column<long>(nullable: false),
                    social_spend = table.Column<double>(nullable: false),
                    objective = table.Column<string>(nullable: true),
                    unique_clicks = table.Column<long>(nullable: false),
                    spend = table.Column<double>(nullable: false),
                    unique_ctr = table.Column<double>(nullable: false),
                    unique_inline_link_click_ctr = table.Column<double>(nullable: false),
                    unique_inline_link_clicks = table.Column<long>(nullable: false),
                    unique_link_clicks_ctr = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignInsights", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_CampaignInsights_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    action_type_id = table.Column<int>(nullable: false),
                    value = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CampaignInsightId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_Actions_CampaignInsights_CampaignInsightId",
                        column: x => x.CampaignInsightId,
                        principalTable: "CampaignInsights",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_ActionTypes_action_type_id",
                        column: x => x.action_type_id,
                        principalTable: "ActionTypes",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CampaignInsightId",
                table: "Actions",
                column: "CampaignInsightId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_action_type_id",
                table: "Actions",
                column: "action_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_AppUserId",
                table: "AdAccounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_BusinessId",
                table: "AdAccounts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_AdSets_CampaignId",
                table: "AdSets",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributionSpecs_AdAccountId",
                table: "AttributionSpecs",
                column: "AdAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInsights_CampaignId",
                table: "CampaignInsights",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AdAccountId",
                table: "Campaigns",
                column: "AdAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AppUserId",
                table: "Campaigns",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRole_AppUsers_AppUserId",
                table: "AppUserRole",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRole_AppUsers_AppUserId",
                table: "AppUserRole");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "AdSets");

            migrationBuilder.DropTable(
                name: "AttributionSpecs");

            migrationBuilder.DropTable(
                name: "CampaignInsights");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "AdAccounts");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRole_AppUsers_AppUserId",
                table: "AppUserRole",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
