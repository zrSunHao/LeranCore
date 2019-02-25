using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.Basic;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class UserInfoCfg : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("UserInfos", "System");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Sex).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.OccupationId).IsRequired();
            builder.Property(x => x.Intro).HasMaxLength(400);
            builder.Property(x => x.PhoneNum).HasMaxLength(20);
            builder.Property(x => x.QQ).HasMaxLength(20);
            builder.Property(x => x.WeChart).HasMaxLength(50);
            builder.Property(x => x.BaseAddressId).IsRequired();
            builder.Property(x => x.CurrentAddressId).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();

            builder.HasIndex(x => x.AccountId);
        }
    }
}
