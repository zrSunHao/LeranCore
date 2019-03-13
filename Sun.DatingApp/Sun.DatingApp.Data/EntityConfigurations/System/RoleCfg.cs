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
            builder.ToTable("Role", "system");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Intro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Active).IsRequired();


            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();

            builder.HasData(new List<Role>()
            {
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "超级管理员",
                    Intro = "超级管理员拥有所有的权限",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "管理员",
                    Intro = "管理员用于管理用户权限",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "用户",
                    Intro = "可以使用基本功能",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                },
            });
        }
    }
}
