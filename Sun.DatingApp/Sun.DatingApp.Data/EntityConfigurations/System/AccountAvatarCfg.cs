using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class AccountAvatarCfg : IEntityTypeConfiguration<AccountAvatar>
    {
        public void Configure(EntityTypeBuilder<AccountAvatar> builder)
        {
            builder.ToTable("AccountAvatar");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.FileName).IsRequired().HasMaxLength(300);
            builder.Property(x => x.FileLength).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(800);
            builder.Property(x => x.FileType).IsRequired().HasMaxLength(300);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
