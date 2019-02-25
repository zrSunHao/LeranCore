using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Entities.Basic;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.EntityConfigurations.Basic;
using Sun.DatingApp.Data.EntityConfigurations.System;

namespace Sun.DatingApp.Data.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region System

        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<RoleOrgItem> RoleOrgItems { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }

        #endregion

        #region Business



        #endregion

        #region Basic

        public DbSet<Region> Districts { get; set; }
        public DbSet<Occupation> Occupations { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region System

            modelBuilder.ApplyConfiguration(new AccountCfg());
            modelBuilder.ApplyConfiguration(new UserInfoCfg());
            modelBuilder.ApplyConfiguration(new RoleCfg());
            modelBuilder.ApplyConfiguration(new RoleOrgItemCfg());
            modelBuilder.ApplyConfiguration(new PromptCfg());
            modelBuilder.ApplyConfiguration(new OrganizationCfg());
            modelBuilder.ApplyConfiguration(new ProfilePictureCfg());

            #endregion

            #region Business



            #endregion

            #region Basic

            modelBuilder.ApplyConfiguration(new RegionCfg());
            modelBuilder.ApplyConfiguration(new OccupationCfg());

            #endregion

        }

    }
}
