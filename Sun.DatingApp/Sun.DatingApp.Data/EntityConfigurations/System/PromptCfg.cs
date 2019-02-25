using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class PromptCfg : IEntityTypeConfiguration<Prompt>
    {
        public void Configure(EntityTypeBuilder<Prompt> builder)
        {
            builder.ToTable("Prompts", "System");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.OrganizationId).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Info).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LastInfo).IsRequired().HasMaxLength(200);
            builder.Property(x => x.UpdateNum).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();

            builder.HasIndex(x => x.Code);
        }
    }
}
