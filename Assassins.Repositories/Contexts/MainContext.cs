using Assassins.DataModels.Actions;
using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.AdImages;
using Assassins.DataModels.Ads;
using Assassins.DataModels.AdSets;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Creatives;
using Assassins.DataModels.LeadForms;
using Microsoft.EntityFrameworkCore;
using System;
using Action = Assassins.DataModels.Actions.Action;

namespace Assassins.DataAccess.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<AdAccount> AdAccounts { get; set; }
        public DbSet<AdAccountHistory> AdAccountHistory { get; set; }
        //public DbSet<AttributionSpec> AttributionSpecs { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignInsight> CampaignInsights { get; set; }
        public DbSet<AdSet> AdSets { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdCreative> AdCreatives { get; set; }
        public DbSet<AdImage> AdImages { get; set; }
        public DbSet<LeadForm> LeadForms { get; set; }
        public DbSet<Targeting> Targeting { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Geolocation> Geolocations { get; set; }
        public DbSet<GeolocationRegionMap> GeolocationRegionMaps { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserDataSync> AppUserDataSyncs { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            //optionsBuilder.EnableSensitiveDataLogging(true);
#endif
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region USERS & ROLES
            modelBuilder.Entity<AppRole>().HasKey(k => k.RoleId);
            modelBuilder.Entity<AppRole>().HasData(new AppRole { RoleId = 1, Name = "Administrator" },
                                                new AppRole { RoleId = 2, Name = "Assassins Club Free" },
                                                new AppRole { RoleId = 3, Name = "Assassins Club Premium" },
                                                new AppRole { RoleId = 4, Name = "Assassins Club Platinum" });
            modelBuilder.Entity<AppUserRole>().HasKey(k => new { k.AppUserId, k.RoleId });
            modelBuilder.Entity<AppUserRole>()
                       .HasOne(k => k.AppUser)
                       .WithMany(k => k.UserRoles)
                       .HasForeignKey(k => k.AppUserId);
            modelBuilder.Entity<AppUserRole>()
                        .HasData(
                                    new AppUserRole() { AppUserId = 1, RoleId = 1 },
                                    new AppUserRole() { AppUserId = 2, RoleId = 1 }
                                );


            modelBuilder.Entity<AppUser>().HasKey(k => k.AppUserId);
            modelBuilder.Entity<AppUser>()
                        .HasMany(k => k.UserRoles)
                        .WithOne(k => k.AppUser)
                        .HasForeignKey(k => k.AppUserId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUser>()
                        .HasMany(k => k.AdAccounts)
                        .WithOne(k => k.AppUser)
                        .HasForeignKey(k => k.AppUserId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUser>()
                        .HasMany(k => k.Campaigns)
                        .WithOne(k => k.AppUser)
                        .HasForeignKey(k => k.AppUserId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUser>()
                        .HasMany(k => k.DataSyncs)
                        .WithOne(k => k.AppUser)
                        .HasForeignKey(k => k.AppUserId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
                        .HasData(new AppUser()
                        {
                            AppUserId = 1,
                            AvatarUrl = "http://free-icon-rainbow.com/i/icon_04062/icon_040629_64.png",
                            ExternalId = "8BNz8FqTVGVjYyXudC6DSZkpiws1",
                            Email = "system@assassinsclub.com",
                            FirstName = "System",
                            LastName = "Bot",
                            CreatedBy = "joe.jordan@assassinsclub.com",
                            CreatedById = 2,
                            ModifiedBy = "joe.jordan@assassinsclub.com",
                            ModifiedById = 2,
                            IsSuspended = false,
                            IsDeleted = false,
                            CreatedOn = DateTime.Parse("1980-10-20 00:00:00.0000000"),
                            ModifiedOn = DateTime.Parse("1980-10-20 00:00:00.0000000")
                        },
                        new AppUser()
                        {
                            AppUserId = 2,
                            AvatarUrl = "https://i0.wp.com/cdn.auth0.com/avatars/dj.png?ssl=1",
                            ExternalId = "lv9iYbUYKdRQ0i700sVt9ZjVFps1",
                            Email = "joe.jordan@outlook.com",
                            FirstName = "Joe",
                            LastName = "Jordan",
                            CreatedBy = "system@assassinsclub.com",
                            CreatedById = 1,
                            ModifiedBy = "system@assassinsclub.com",
                            ModifiedById = 1,
                            IsSuspended = false,
                            IsDeleted = false,
                            CreatedOn = DateTime.Parse("1980-10-20 00:00:00.0000000"),
                            ModifiedOn = DateTime.Parse("1980-10-20 00:00:00.0000000")
                        },
                        new AppUser()
                        {
                            AppUserId = 3,
                            AvatarUrl = "https://i0.wp.com/cdn.auth0.com/avatars/jj.png?ssl=1",
                            ExternalId = "x1EZhRH3tVfwTEsE2f2nHJce4yy2",
                            Email = "joe.jordan25@gmail.com",
                            FirstName = "Joe",
                            LastName = "Jordan",
                            CreatedBy = "system@assassinsclub.com",
                            CreatedById = 1,
                            ModifiedBy = "system@assassinsclub.com",
                            ModifiedById = 1,
                            IsSuspended = false,
                            IsDeleted = false,
                            CreatedOn = DateTime.Parse("1980-10-20 00:00:00.0000000"),
                            ModifiedOn = DateTime.Parse("1980-10-20 00:00:00.0000000")
                        });
            #endregion USERS & ROLES

            #region Data Syncs
            modelBuilder.Entity<AppUserDataSync>().HasKey(k => k.Id);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.AdAccounts)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.Campaigns)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.AdSets)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.Ads)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.AdCreatives)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.AdImages)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUserDataSync>()
                        .HasMany(k => k.LeadForms)
                        .WithOne(k => k.AppUserDataSync)
                        .HasForeignKey(k => k.AppUserDataSyncId)
                        .OnDelete(DeleteBehavior.Restrict);
            #endregion Data Syncs

            #region Ad Accounts

            modelBuilder.Entity<AdAccount>().HasKey(k => k.account_id);
            modelBuilder.Entity<AdAccount>()
                                .Property(k => k.account_id)
                                .ValueGeneratedNever();
            modelBuilder.Entity<AdAccount>()
                                .HasMany(k => k.campaigns)
                                .WithOne(k => k.AdAccount)
                                .HasForeignKey(k => k.account_id)
                                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AdAccount>()
                                .HasMany(k => k.adsets)
                                .WithOne(k => k.AdAccount)
                                .HasForeignKey(k => k.account_id)
                                .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<AdAccount>()
            //                    .HasMany(k => k.attribution_spec)
            //                    .WithOne(k => k.AdAccount)
            //                    .HasForeignKey(k => k.account_id)
            //                    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AdAccount>()
                                .HasMany(k => k.ads)
                                .WithOne(k => k.AdAccount)
                                .HasForeignKey(k => k.account_id)
                                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AdAccount>()
                                .HasMany(k => k.adcreatives)
                                .WithOne(k => k.AdAccount)
                                .HasForeignKey(k => k.account_id)
                                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Business>().HasKey(k => k.id);
            modelBuilder.Entity<Business>()
                            .Property(k => k.id)
                            .ValueGeneratedNever();
            modelBuilder.Entity<Business>()
                        .HasMany(k => k.AdAccounts)
                        .WithOne(k => k.business)
                        .HasForeignKey(k => k.business_id)
                        .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<AttributionSpec>().HasKey(k => k.AaId);
            #endregion Ad Accounts

            #region Ad Account History

            modelBuilder.Entity<AdAccountHistory>().HasKey(k => new { k.AppUserDataSyncId, k.account_id });

            #endregion Ad Account History

            #region Campaigns
            modelBuilder.Entity<Campaign>().HasKey(k => k.id);
            modelBuilder.Entity<Campaign>()
                            .Property(k => k.id)
                            .ValueGeneratedNever();
            modelBuilder.Entity<Campaign>()
                        .HasMany(k => k.CampaignInsights)
                        .WithOne(k => k.Campaign)
                        .HasForeignKey(k => k.campaign_id)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Campaign>()
                        .HasMany(k => k.adsets)
                        .WithOne(k => k.Campaign)
                        .HasForeignKey(k => k.campaign_id)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Campaign>()
                        .HasMany(k => k.ads)
                        .WithOne(k => k.Campaign)
                        .HasForeignKey(k => k.campaign_id)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CampaignInsight>().HasKey(k => k.id);
            modelBuilder.Entity<CampaignInsight>()
                        .HasMany(k => k.actions)
                        .WithOne(k => k.CampaignInsight)
                        .HasForeignKey(k => k.campaign_insight_id)
                        .OnDelete(DeleteBehavior.Restrict);
            #endregion Campaigns

            #region AdSets
            modelBuilder.Entity<AdSet>().HasKey(k => k.id);
            modelBuilder.Entity<AdSet>()
                        .Property(k => k.id)
                        .ValueGeneratedNever();
            modelBuilder.Entity<AdSet>()
                        .HasMany(k => k.Ads)
                        .WithOne(k => k.AdSet)
                        .HasForeignKey(k => k.adset_id)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AdSet>()
                        .HasOne(K => K.targeting)
                        .WithOne(k => k.AdSet)
                        .HasForeignKey<Targeting>(k => k.adset_id)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Targeting>().HasKey(k => k.adset_id);
            modelBuilder.Entity<Targeting>()
                        .Property(k => k.adset_id)
                        .ValueGeneratedNever();
            modelBuilder.Entity<Targeting>()
                        .HasOne(K => K.AdSet)
                        .WithOne(k => k.targeting)
                        .HasForeignKey<AdSet>(k => k.id)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Targeting>()
                        .HasOne(K => K.geo_locations)
                        .WithOne(k => k.Targeting)
                        .HasForeignKey<Geolocation>(k => k.adset_id);
            modelBuilder.Entity<Targeting>()
                        .Property(k => k.publisher_platforms)
                        .HasConversion(k => string.Join(',', k), k => k.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<Targeting>()
                        .Property(k => k.facebook_positions)
                        .HasConversion(k => string.Join(',', k), k => k.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<Targeting>()
                        .Property(k => k.instagram_positions)
                        .HasConversion(k => string.Join(',', k), k => k.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<Targeting>()
                        .Property(k => k.device_platforms)
                        .HasConversion(k => string.Join(',', k), k => k.Split(',', StringSplitOptions.RemoveEmptyEntries));


            modelBuilder.Entity<Geolocation>().HasKey(k => k.adset_id);
            modelBuilder.Entity<Geolocation>()
                        .Property(k => k.adset_id)
                        .ValueGeneratedNever();
            modelBuilder.Entity<GeolocationRegionMap>().HasKey(k => new { k.adset_id, k.key });

            modelBuilder.Entity<Geolocation>()
                        .HasMany(k => k.region_maps)
                        .WithOne(k => k.GeoLocation)
                        .HasForeignKey(k => k.adset_id)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Geolocation>()
                        .Property(k => k.location_types)
                        .HasConversion(k => string.Join(',', k), k => k.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<Region>().HasKey(k => k.key);
            modelBuilder.Entity<Region>()
                        .HasMany(k => k.GeoLocationRegionMaps)
                        .WithOne(k => k.Region)
                        .HasForeignKey(k => k.key)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Region>()
                        .Property(k => k.key)
                        .ValueGeneratedNever();

            #endregion AdSets

            #region Ads
            modelBuilder.Entity<Ad>().HasKey(k => k.id);
            modelBuilder.Entity<Ad>()
                        .Property(k => k.id)
                        .ValueGeneratedNever();
            #endregion Ads

            #region Ad Creatives
            modelBuilder.Entity<AdCreative>().HasKey(k => k.id);
            modelBuilder.Entity<AdCreative>()
                        .Property(k => k.id)
                        .ValueGeneratedNever();

            #endregion Ad Creatives

            #region Ad Images
            modelBuilder.Entity<LeadForm>().HasKey(k => k.id);
            modelBuilder.Entity<LeadForm>()
                        .Property(k => k.id)
                        .ValueGeneratedNever();
            //modelBuilder.Entity<LeadForm>()
            //            .HasMany(k => k.Ad)
            //            .WithOne(k => k.AdImage)
            //            .HasForeignKey(k => k.adimage_id)
            //            .OnDelete(DeleteBehavior.Restrict);
            #endregion Ad Images

            #region Actions

            modelBuilder.Entity<ActionType>().HasKey(k => k.AaId);
            modelBuilder.Entity<Action>().HasKey(k => k.AaId);
            modelBuilder.Entity<Action>()
                        .HasOne(k => k.action_type)
                        .WithMany(k => k.Actions)
                        .HasForeignKey(k => k.action_type_id)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VideoP75WatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<CostPer10SecVideoView>().HasBaseType<Action>();
            modelBuilder.Entity<CostPerActionType>().HasBaseType<Action>();
            modelBuilder.Entity<CostPerThroughPlay>().HasBaseType<Action>();
            modelBuilder.Entity<CostPerUniqueActionType>().HasBaseType<Action>();
            modelBuilder.Entity<UniqueAction>().HasBaseType<Action>();
            modelBuilder.Entity<Video10SecWatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<Video30SecWatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoAvgPercentWatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoAvgTimeWatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoP100WatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoP25WatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoP50WatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoP75WatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoP95WatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<VideoThruPlayWatchedAction>().HasBaseType<Action>();
            modelBuilder.Entity<WebsiteCtr>().HasBaseType<Action>();
            #endregion Actions

            base.OnModelCreating(modelBuilder);
        }
    }
}
