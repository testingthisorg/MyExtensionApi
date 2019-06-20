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
                    AdAssassinId = table.Column<string>(nullable: true),
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
                name: "Business",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserDataSync",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    AdAccountsCompleted = table.Column<bool>(nullable: false),
                    CampaignsCompleted = table.Column<bool>(nullable: false),
                    AdSetsCompleted = table.Column<bool>(nullable: false),
                    AdsCompleted = table.Column<bool>(nullable: false),
                    CreativesCompleted = table.Column<bool>(nullable: false),
                    LeadFormsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDataSync", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserDataSync_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdAccounts",
                columns: table => new
                {
                    account_id = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    amount_spent = table.Column<long>(nullable: false),
                    account_status = table.Column<int>(nullable: false),
                    age = table.Column<double>(nullable: false),
                    balance = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    business_id = table.Column<long>(nullable: true),
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
                    table.PrimaryKey("PK_AdAccounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_AdAccounts_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdAccounts_Business_business_id",
                        column: x => x.business_id,
                        principalTable: "Business",
                        principalColumn: "id",
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
                    account_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributionSpecs", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_AttributionSpecs_AdAccounts_account_id",
                        column: x => x.account_id,
                        principalTable: "AdAccounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    account_id = table.Column<long>(nullable: false),
                    budget_rebalance_flag = table.Column<bool>(nullable: false),
                    budget_remaining = table.Column<int>(nullable: false),
                    buying_type = table.Column<string>(nullable: true),
                    can_create_brand_lift_study = table.Column<bool>(nullable: false),
                    can_use_spend_cap = table.Column<bool>(nullable: false),
                    configured_status = table.Column<string>(nullable: true),
                    created_time = table.Column<DateTime>(nullable: false),
                    effective_status = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Campaigns", x => x.id);
                    table.ForeignKey(
                        name: "FK_Campaigns_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_AdAccounts_account_id",
                        column: x => x.account_id,
                        principalTable: "AdAccounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdSets",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    campaign_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSets", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_AdSets_Campaigns_campaign_id",
                        column: x => x.campaign_id,
                        principalTable: "Campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignInsights",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    campaign_id = table.Column<long>(nullable: false),
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
                    table.PrimaryKey("PK_CampaignInsights", x => x.id);
                    table.ForeignKey(
                        name: "FK_CampaignInsights_Campaigns_campaign_id",
                        column: x => x.campaign_id,
                        principalTable: "Campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    AaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    campaign_insight_id = table.Column<long>(nullable: true),
                    action_type_id = table.Column<int>(nullable: false),
                    value = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.AaId);
                    table.ForeignKey(
                        name: "FK_Actions_ActionTypes_action_type_id",
                        column: x => x.action_type_id,
                        principalTable: "ActionTypes",
                        principalColumn: "AaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_CampaignInsights_campaign_insight_id",
                        column: x => x.campaign_insight_id,
                        principalTable: "CampaignInsights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "AppUserId", "AdAssassinId", "AvatarUrl", "CreatedBy", "CreatedById", "CreatedOn", "Email", "ExternalId", "FirstName", "IsDeleted", "IsSuspended", "LastName", "ModifiedBy", "ModifiedById", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, null, "http://free-icon-rainbow.com/i/icon_04062/icon_040629_64.png", "joe.jordan@assassinsclub.com", 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@assassinsclub.com", "8BNz8FqTVGVjYyXudC6DSZkpiws1", "System", false, false, "Bot", "joe.jordan@assassinsclub.com", 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "https://i0.wp.com/cdn.auth0.com/avatars/dj.png?ssl=1", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe.jordan@outlook.com", "lv9iYbUYKdRQ0i700sVt9ZjVFps1", "Joe", false, false, "Jordan", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "https://i0.wp.com/cdn.auth0.com/avatars/jj.png?ssl=1", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe.jordan25@gmail.com", "x1EZhRH3tVfwTEsE2f2nHJce4yy2", "Joe", false, false, "Jordan", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_Actions_action_type_id",
                table: "Actions",
                column: "action_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_campaign_insight_id",
                table: "Actions",
                column: "campaign_insight_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_AppUserId",
                table: "AdAccounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_business_id",
                table: "AdAccounts",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdSets_campaign_id",
                table: "AdSets",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDataSync_AppUserId",
                table: "AppUserDataSync",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributionSpecs_account_id",
                table: "AttributionSpecs",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInsights_campaign_id",
                table: "CampaignInsights",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AppUserId",
                table: "Campaigns",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_account_id",
                table: "Campaigns",
                column: "account_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "AdSets");

            migrationBuilder.DropTable(
                name: "AppUserDataSync");

            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "AttributionSpecs");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "CampaignInsights");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "AdAccounts");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
