using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.Basic;

namespace Sun.DatingApp.Data.EntityConfigurations.Basic
{
    public class BasicRegionCfg : IEntityTypeConfiguration<BasicRegion>
    {
        public void Configure(EntityTypeBuilder<BasicRegion> builder)
        {
            builder.ToTable("BasicRegion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.RegionCode).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ShortName).HasMaxLength(50);
            builder.Property(x => x.LayerLevel).IsRequired();
            builder.Property(x => x.CityCode).HasMaxLength(20);
            builder.Property(x => x.ZipCode).HasMaxLength(20);
            builder.Property(x => x.MergerName).HasMaxLength(150);
            builder.Property(x => x.Lng).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Lat).IsRequired().HasMaxLength(60);
            builder.Property(x => x.PinYin).HasMaxLength(100);
        }
    }
}
