using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class RoleCfg : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "System");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Intro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Active).IsRequired();


            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();

            builder.HasMany<RolePermission>(x => x.RolePermissions).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            builder.HasMany<Account>(x => x.Accounts).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            builder.HasData(new List<Role>()
            {
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "超级管理员",
                    Code = "SuperAdmin",
                    Intro = "超级管理员拥有所有的权限",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "管理员",
                    Code = "Admin",
                    Intro = "管理员用于管理用户权限",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "用户",
                    Code = "User",
                    Intro = "可以使用基本功能",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                },
            });
        }
    }
}
