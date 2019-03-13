using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class ProfilePictureCfg : IEntityTypeConfiguration<ProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {
            builder.ToTable("ProfilePicture", "system");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.FileName).HasMaxLength(100);
            builder.Property(x => x.FileType).HasMaxLength(20);
            builder.Property(x => x.Url).HasMaxLength(200);
            builder.Property(x => x.FileLength).HasMaxLength(20);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
