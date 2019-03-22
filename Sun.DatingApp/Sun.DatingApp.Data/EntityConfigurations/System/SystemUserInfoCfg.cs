using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.Basic;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class SystemUserInfoCfg : IEntityTypeConfiguration<SystemUserInfo>
    {
        public void Configure(EntityTypeBuilder<SystemUserInfo> builder)
        {
            builder.ToTable("SystemUserInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AccountId).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Sex).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();

            builder.Property(x => x.QQ).HasMaxLength(20);
            builder.Property(x => x.WeChart).HasMaxLength(50);

            builder.Property(x => x.Occupation).HasMaxLength(150);
            builder.Property(x => x.Company).HasMaxLength(150);
            builder.Property(x => x.Address).HasMaxLength(150);
            builder.Property(x => x.Intro).HasMaxLength(350);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
