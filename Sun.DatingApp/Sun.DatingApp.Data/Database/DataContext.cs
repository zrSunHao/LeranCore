﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<SystemAccount> SystemAccounts { get; set; }
        public DbSet<SystemAccountAvatar> SystemAccountAvatars { get; set; }
        public DbSet<SystemRolePermission> RolePermissions { get; set; }
        public DbSet<SystemPermission> Permissions { get; set; }
        public DbSet<SystemUserInfo> UserInfos { get; set; }
        public DbSet<SystemRole> Roles { get; set; }
        public DbSet<SystemMenu> Menus { get; set; }
        public DbSet<SystemPage> Pages { get; set; }

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
            modelBuilder.ApplyConfiguration(new SystemAccountAvatarCfg());
            modelBuilder.ApplyConfiguration(new RolePermissionCfg());
            modelBuilder.ApplyConfiguration(new PermissionCfg());
            modelBuilder.ApplyConfiguration(new SystemUserInfoCfg());
            modelBuilder.ApplyConfiguration(new SystemRoleCfg());
            modelBuilder.ApplyConfiguration(new SystemMenuCfg());
            modelBuilder.ApplyConfiguration(new SystemPageCfg());

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
