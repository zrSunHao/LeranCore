﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class SystemMenuCfg : IEntityTypeConfiguration<SystemMenu>
    {
        public void Configure(EntityTypeBuilder<SystemMenu> builder)
        {
            builder.ToTable("SystemMenu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Intro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.TagColor).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Order).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
