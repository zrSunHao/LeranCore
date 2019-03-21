using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.Basic;

namespace Sun.DatingApp.Data.EntityConfigurations.Basic
{
    public class BasicOccupationCfg : IEntityTypeConfiguration<BasicOccupation>
    {
        public void Configure(EntityTypeBuilder<BasicOccupation> builder)
        {
            builder.ToTable("BasicOccupation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ParentCode).IsRequired().HasMaxLength(200);
        }
    }
}
