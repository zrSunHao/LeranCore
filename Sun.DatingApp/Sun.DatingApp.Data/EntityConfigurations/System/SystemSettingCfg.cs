using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class SystemSettingCfg : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            builder.ToTable("SystemSetting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Key).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Id).HasMaxLength(500);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
