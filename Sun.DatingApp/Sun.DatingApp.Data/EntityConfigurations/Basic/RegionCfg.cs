﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.Basic;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.Basic
{
    public class RegionCfg : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions", "Basic");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.RegionCode).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ShortName).HasMaxLength(50);
            builder.Property(x => x.LayerLevel).IsRequired();
            builder.Property(x => x.CityCode).HasMaxLength(20);
            builder.Property(x => x.ZipCode).HasMaxLength(20);
            builder.Property(x => x.MergerName).HasMaxLength(150);
            builder.Property(x => x.Lng).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Lat).IsRequired().HasMaxLength(60);
            builder.Property(x => x.PinYin).HasMaxLength(100);

            builder.HasIndex(x => x.RegionCode);
            builder.HasIndex(x => x.LayerLevel);
            builder.HasMany(x => x.Children).WithOne(x => x.Parent).HasForeignKey(x => x.ParentId);
            builder.HasMany<UserInfo>(x => x.UserInfos).WithOne(x => x.Region).HasForeignKey(x => x.BaseAddressId);
            builder.HasMany<UserInfo>(x => x.UserInfos).WithOne(x => x.Region).HasForeignKey(x => x.CurrentAddressId);
        }
    }
}
