using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class OrganizationCfg : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization", "system");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Remark).HasMaxLength(200);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
