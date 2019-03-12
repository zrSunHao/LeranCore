using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class RolePageCfg : IEntityTypeConfiguration<RolePage>
    {
        public void Configure(EntityTypeBuilder<RolePage> builder)
        {
            builder.ToTable("RolePage", "RolePermissions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();
            builder.Property(x => x.PageId).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();
        }
    }
}
