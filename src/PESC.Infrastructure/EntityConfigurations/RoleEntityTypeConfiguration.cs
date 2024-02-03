using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Infrastructure.EntityConfigurations;
internal class RoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("SCRM_ROLE_MSCD");
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => new { t.TenantId, t.UserRoleId }).IsUnique();
        builder.Property(t => t.Id).ValueGeneratedOnAdd().UseSnowFlakeValueGenerator();

        builder.Property(b => b.TenantId).HasMaxLength(32).IsRequired();
        builder.Property(b => b.UserRoleId).HasMaxLength(32).IsRequired();
        builder.Property(b => b.CreatorId).HasMaxLength(32).IsRequired();
        builder.Property(b => b.CreationTime).HasDefaultValue(DateTime.Now);
        builder.Property(b => b.LastModificationTime).HasDefaultValue(DateTime.Now);
    }
}

