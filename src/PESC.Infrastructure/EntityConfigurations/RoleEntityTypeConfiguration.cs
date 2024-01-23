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
internal class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("SCRM_ROLE_MSCD");
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => new { t.Factory, t.RoleName }).IsUnique();
        builder.Property(t => t.Id).ValueGeneratedOnAdd().UseSnowFlakeValueGenerator();

        builder.Property(b => b.Factory).HasMaxLength(32).IsRequired();
        builder.Property(b => b.RoleName).HasMaxLength(32).IsRequired();
    }
}

