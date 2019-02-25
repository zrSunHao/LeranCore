using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.EntityConfigurations.System
{
    public class AccountCfg : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts", "System");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RoleId).IsRequired();
            builder.Property(x => x.RoleCode).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.Forbiden).IsRequired();
            builder.Property(x => x.AccessFailedCount).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Deleted).IsRequired();

            builder.HasIndex(x => x.Email);
        }
    }
}
