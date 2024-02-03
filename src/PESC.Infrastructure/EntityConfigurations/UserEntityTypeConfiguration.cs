using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;

namespace PESC.Infrastructure.EntityConfigurations;
internal class UserEntityTypeConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("SCRM_USER_MSCD");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd().UseSnowFlakeValueGenerator();

        builder.HasIndex(t => new { t.TenantId, t.LoginId }).IsUnique();
        builder.Property(b => b.TenantId).HasMaxLength(32).IsRequired();
        builder.Property(b => b.LoginId).HasMaxLength(32).IsRequired();
        builder.Property(b => b.Name).HasMaxLength(32);
        builder.Property(b => b.Desc).HasMaxLength(128);
        builder.Property(b => b.Password).HasMaxLength(256).IsRequired();
        builder.Property(b => b.CreationTime).HasDefaultValue(DateTime.Now);
        builder.Property(b => b.LastModificationTime).HasDefaultValue(DateTime.Now);
        builder.Property(b => b.LastLoginTime).HasDefaultValue(DateTime.Now);


        builder.HasMany(e => e.Roles).WithMany(e => e.Users).UsingEntity("SCRM_USER_ROLE");
    }
}

