using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class PageCfg : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Permissions", "Page");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Intro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.TagColor).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MenuId).IsRequired();
            builder.Property(x => x.ModuleId).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
