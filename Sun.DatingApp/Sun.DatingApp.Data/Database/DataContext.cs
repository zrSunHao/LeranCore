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
        public DbSet<AccountAvatar> AccountAvatars { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }

        #endregion

        #region Business



        #endregion

        #region Basic

        public DbSet<BasicRegion> BasicRegion { get; set; }
        public DbSet<BasicOccupation> BasicOccupation { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region System

            modelBuilder.ApplyConfiguration(new AccountCfg());
            modelBuilder.ApplyConfiguration(new AccountAvatarCfg());
            modelBuilder.ApplyConfiguration(new RolePermissionCfg());
            modelBuilder.ApplyConfiguration(new PermissionCfg());
            modelBuilder.ApplyConfiguration(new UserInfoCfg());
            modelBuilder.ApplyConfiguration(new RoleCfg());
            modelBuilder.ApplyConfiguration(new PromptCfg());
            modelBuilder.ApplyConfiguration(new OrganizationCfg());
            modelBuilder.ApplyConfiguration(new ProfilePictureCfg());
            modelBuilder.ApplyConfiguration(new MenuCfg());
            modelBuilder.ApplyConfiguration(new PageCfg());

            #endregion

            #region Business



            #endregion

            #region Basic

            modelBuilder.ApplyConfiguration(new BasicRegionCfg());
            modelBuilder.ApplyConfiguration(new BasicOccupationCfg());

            #endregion

        }

    }
}
