using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class RoleOrgItemCfg : IEntityTypeConfiguration<RoleOrgItem>
    {
        public void Configure(EntityTypeBuilder<RoleOrgItem> builder)
        {
            builder.ToTable("RoleOrgItems", "System");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.OrganizationId).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
