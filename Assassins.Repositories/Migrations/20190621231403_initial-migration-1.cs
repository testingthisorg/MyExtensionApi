using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassins.DataAccess.Migrations
{
    public partial class initialmigration1 : Migration
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
                    id = table.Column<long>(nullable: true),
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
                name: "Regions",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "Targeting",
                columns: table => new
                {
                    adset_id = table.Column<long>(nullable: false),
                    age_max = table.Column<int>(nullable: false),
                    age_min = table.Column<int>(nullable: false),
                    publisher_platforms = table.Column<string>(nullable: true),
                    facebook_positions = table.Column<string>(nullable: true),
                    instagram_positions = table.Column<string>(nullable: true),
                    device_platforms = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targeting", x => x.adset_id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserDataSyncs",
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
                    table.PrimaryKey("PK_AppUserDataSyncs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserDataSyncs_AppUsers_AppUserId",
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
                name: "AdAccountHistory",
                columns: table => new
                {
                    AppUserDataSyncId = table.Column<long>(nullable: false),
                    account_id = table.Column<long>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    amount_spent = table.Column<long>(nullable: false),
                    account_status = table.Column<int>(nullable: false),
                    age = table.Column<double>(nullable: false),
                    balance = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    business_id = table.Column<long>(nullable: true),
                    businessid = table.Column<long>(nullable: true),
                    business_city = table.Column<string>(nullable: true),
                    business_country_code = table.Column<string>(nullable: true),
                    business_name = table.Column<string>(nullable: true),
                    business_street = table.Column<string>(nullable: true),
                    business_street2 = table.Column<string>(nullable: true),
                    created_time = table.Column<DateTime>(nullable: false),
                    currency = table.Column<string>(nullable: true),
                    disable_reason = table.Column<int>(nullable: false),
                    end_advertiser = table.Column<long>(nullable: true),
                    end_advertiser_name = table.Column<string>(nullable: true),
                    fb_entity = table.Column<int>(nullable: false),
                    min_campaign_group_spend_cap = table.Column<int>(nullable: false),
                    min_daily_budget = table.Column<int>(nullable: false),
                    owner = table.Column<long>(nullable: false),
                    spend_cap = table.Column<int>(nullable: false),
                    timezone_id = table.Column<int>(nullable: false),
                    timezone_name = table.Column<string>(nullable: true),
                    timezone_offset_hours_utc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdAccountHistory", x => new { x.AppUserDataSyncId, x.account_id });
                    table.ForeignKey(
                        name: "FK_AdAccountHistory_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdAccountHistory_Business_businessid",
                        column: x => x.businessid,
                        principalTable: "Business",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Geolocations",
                columns: table => new
                {
                    adset_id = table.Column<long>(nullable: false),
                    location_types = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geolocations", x => x.adset_id);
                    table.ForeignKey(
                        name: "FK_Geolocations_Targeting_adset_id",
                        column: x => x.adset_id,
                        principalTable: "Targeting",
                        principalColumn: "adset_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdAccounts",
                columns: table => new
                {
                    account_id = table.Column<long>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false),
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
                    end_advertiser = table.Column<long>(nullable: true),
                    end_advertiser_name = table.Column<string>(nullable: true),
                    fb_entity = table.Column<int>(nullable: false),
                    min_campaign_group_spend_cap = table.Column<int>(nullable: false),
                    min_daily_budget = table.Column<int>(nullable: false),
                    owner = table.Column<long>(nullable: false),
                    spend_cap = table.Column<int>(nullable: false),
                    timezone_id = table.Column<int>(nullable: false),
                    timezone_name = table.Column<string>(nullable: true),
                    timezone_offset_hours_utc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdAccounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_AdAccounts_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AdImages",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false),
                    url_128 = table.Column<string>(nullable: true),
                    account_id = table.Column<long>(nullable: false),
                    created_time = table.Column<DateTime>(nullable: false),
                    hash = table.Column<string>(nullable: true),
                    height = table.Column<int>(nullable: false),
                    is_associated_creatives_in_adgroups = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    original_height = table.Column<int>(nullable: false),
                    original_width = table.Column<int>(nullable: false),
                    permalink_url = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    update_time = table.Column<DateTime>(nullable: false),
                    width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdImages_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadForms",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadForms", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeadForms_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeolocationRegionMaps",
                columns: table => new
                {
                    adset_id = table.Column<long>(nullable: false),
                    key = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeolocationRegionMaps", x => new { x.adset_id, x.key });
                    table.ForeignKey(
                        name: "FK_GeolocationRegionMaps_Geolocations_adset_id",
                        column: x => x.adset_id,
                        principalTable: "Geolocations",
                        principalColumn: "adset_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeolocationRegionMaps_Regions_key",
                        column: x => x.key,
                        principalTable: "Regions",
                        principalColumn: "key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false),
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
                    source_campaign_id = table.Column<long>(nullable: true),
                    start_time = table.Column<DateTime>(nullable: false),
                    stop_time = table.Column<DateTime>(nullable: true),
                    updated_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.id);
                    table.ForeignKey(
                        name: "FK_Campaigns_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AdCreatives",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false),
                    account_id = table.Column<long>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    call_to_action_type = table.Column<string>(nullable: true),
                    effective_object_story_id = table.Column<string>(nullable: true),
                    image_hash = table.Column<string>(nullable: true),
                    image_url = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    adimage_id = table.Column<string>(nullable: true),
                    AdImageid = table.Column<string>(nullable: true),
                    effective_instagram_story_id = table.Column<long>(nullable: true),
                    instagram_actor_id = table.Column<long>(nullable: true),
                    instagram_permalink_url = table.Column<string>(nullable: true),
                    instagram_story_id = table.Column<long>(nullable: true),
                    link_og_id = table.Column<long>(nullable: true),
                    link_url = table.Column<string>(nullable: true),
                    messenger_sponsored_message = table.Column<string>(nullable: true),
                    object_id = table.Column<long>(nullable: true),
                    object_story_id = table.Column<string>(nullable: true),
                    object_type = table.Column<string>(nullable: true),
                    object_url = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    template_url = table.Column<string>(nullable: true),
                    thumbnail_url = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    url_tags = table.Column<string>(nullable: true),
                    video_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCreatives", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdCreatives_AdImages_AdImageid",
                        column: x => x.AdImageid,
                        principalTable: "AdImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdCreatives_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdCreatives_AdAccounts_account_id",
                        column: x => x.account_id,
                        principalTable: "AdAccounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdSets",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false),
                    campaign_id = table.Column<long>(nullable: false),
                    account_id = table.Column<long>(nullable: false),
                    bid_strategy = table.Column<string>(nullable: true),
                    billing_event = table.Column<string>(nullable: true),
                    budget_remaining = table.Column<int>(nullable: false),
                    configured_status = table.Column<string>(nullable: true),
                    created_time = table.Column<DateTime>(nullable: false),
                    daily_budget = table.Column<int>(nullable: false),
                    destination_type = table.Column<string>(nullable: true),
                    effective_status = table.Column<string>(nullable: true),
                    end_time = table.Column<DateTime>(nullable: false),
                    lifetime_budget = table.Column<int>(nullable: false),
                    lifetime_imps = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    optimization_goal = table.Column<string>(nullable: true),
                    optimization_sub_event = table.Column<string>(nullable: true),
                    recurring_budget_semantics = table.Column<bool>(nullable: false),
                    source_adset_id = table.Column<long>(nullable: false),
                    start_time = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    updated_time = table.Column<DateTime>(nullable: false),
                    use_new_app_click = table.Column<bool>(nullable: false),
                    is_dynamic_creative = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSets", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdSets_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdSets_AdAccounts_account_id",
                        column: x => x.account_id,
                        principalTable: "AdAccounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdSets_Campaigns_campaign_id",
                        column: x => x.campaign_id,
                        principalTable: "Campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdSets_Targeting_id",
                        column: x => x.id,
                        principalTable: "Targeting",
                        principalColumn: "adset_id",
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
                name: "Ads",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    AppUserDataSyncId = table.Column<long>(nullable: false),
                    account_id = table.Column<long>(nullable: false),
                    campaign_id = table.Column<long>(nullable: false),
                    adset_id = table.Column<long>(nullable: false),
                    bid_type = table.Column<string>(nullable: true),
                    configured_status = table.Column<string>(nullable: true),
                    created_time = table.Column<DateTime>(nullable: false),
                    effective_status = table.Column<string>(nullable: true),
                    last_updated_by_app_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    source_ad_id = table.Column<long>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    updated_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ads_AppUserDataSyncs_AppUserDataSyncId",
                        column: x => x.AppUserDataSyncId,
                        principalTable: "AppUserDataSyncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_AdAccounts_account_id",
                        column: x => x.account_id,
                        principalTable: "AdAccounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_AdSets_adset_id",
                        column: x => x.adset_id,
                        principalTable: "AdSets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_Campaigns_campaign_id",
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
                columns: new[] { "AppUserId", "AdAssassinId", "AvatarUrl", "CreatedBy", "CreatedById", "CreatedOn", "Email", "ExternalId", "FirstName", "IsDeleted", "IsSuspended", "LastName", "ModifiedBy", "ModifiedById", "ModifiedOn", "id" },
                values: new object[,]
                {
                    { 1, null, "http://free-icon-rainbow.com/i/icon_04062/icon_040629_64.png", "joe.jordan@assassinsclub.com", 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@assassinsclub.com", "8BNz8FqTVGVjYyXudC6DSZkpiws1", "System", false, false, "Bot", "joe.jordan@assassinsclub.com", 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, null, "https://i0.wp.com/cdn.auth0.com/avatars/dj.png?ssl=1", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe.jordan@outlook.com", "lv9iYbUYKdRQ0i700sVt9ZjVFps1", "Joe", false, false, "Jordan", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, null, "https://i0.wp.com/cdn.auth0.com/avatars/jj.png?ssl=1", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe.jordan25@gmail.com", "x1EZhRH3tVfwTEsE2f2nHJce4yy2", "Joe", false, false, "Jordan", "system@assassinsclub.com", 1, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                name: "IX_AdAccountHistory_AppUserId",
                table: "AdAccountHistory",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccountHistory_businessid",
                table: "AdAccountHistory",
                column: "businessid");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_AppUserDataSyncId",
                table: "AdAccounts",
                column: "AppUserDataSyncId");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_AppUserId",
                table: "AdAccounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdAccounts_business_id",
                table: "AdAccounts",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdCreatives_AdImageid",
                table: "AdCreatives",
                column: "AdImageid");

            migrationBuilder.CreateIndex(
                name: "IX_AdCreatives_AppUserDataSyncId",
                table: "AdCreatives",
                column: "AppUserDataSyncId");

            migrationBuilder.CreateIndex(
                name: "IX_AdCreatives_account_id",
                table: "AdCreatives",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdImages_AppUserDataSyncId",
                table: "AdImages",
                column: "AppUserDataSyncId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AppUserDataSyncId",
                table: "Ads",
                column: "AppUserDataSyncId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_account_id",
                table: "Ads",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_adset_id",
                table: "Ads",
                column: "adset_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_campaign_id",
                table: "Ads",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdSets_AppUserDataSyncId",
                table: "AdSets",
                column: "AppUserDataSyncId");

            migrationBuilder.CreateIndex(
                name: "IX_AdSets_account_id",
                table: "AdSets",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdSets_campaign_id",
                table: "AdSets",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDataSyncs_AppUserId",
                table: "AppUserDataSyncs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInsights_campaign_id",
                table: "CampaignInsights",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AppUserDataSyncId",
                table: "Campaigns",
                column: "AppUserDataSyncId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AppUserId",
                table: "Campaigns",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_account_id",
                table: "Campaigns",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_GeolocationRegionMaps_key",
                table: "GeolocationRegionMaps",
                column: "key");

            migrationBuilder.CreateIndex(
                name: "IX_LeadForms_AppUserDataSyncId",
                table: "LeadForms",
                column: "AppUserDataSyncId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "AdAccountHistory");

            migrationBuilder.DropTable(
                name: "AdCreatives");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "GeolocationRegionMaps");

            migrationBuilder.DropTable(
                name: "LeadForms");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "CampaignInsights");

            migrationBuilder.DropTable(
                name: "AdImages");

            migrationBuilder.DropTable(
                name: "AdSets");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Geolocations");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Targeting");

            migrationBuilder.DropTable(
                name: "AdAccounts");

            migrationBuilder.DropTable(
                name: "AppUserDataSyncs");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
