using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.Basic;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.Basic
{
    public class OccupationCfg : IEntityTypeConfiguration<Occupation>
    {
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.ToTable("Occupations", "Basic");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ParentCode).IsRequired().HasMaxLength(200);

            builder.HasIndex(x => x.Code);
            builder.HasMany(x => x.Children).WithOne(x => x.Parent).HasForeignKey(x=>x.ParentId);
            builder.HasMany<UserInfo>(x => x.UserInfos).WithOne(x => x.Occupation)
                .HasForeignKey(x => x.OccupationId);
        }
    }
}
