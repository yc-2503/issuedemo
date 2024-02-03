using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.DeliverAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;

namespace PESC.Infrastructure
{
    public partial class ApplicationDbContext : AppDbContextBase
    {
        public ApplicationDbContext(DbContextOptions options, IMediator mediator, IServiceProvider provider) : base(
            options, mediator, provider)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeliverRecordConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());

        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            ConfigureStronglyTypedIdValueConverter(configurationBuilder);
            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<DeliverRecord> DeliverRecords => Set<DeliverRecord>();
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users => Set<User>();
        /// <summary>
        /// 权限组
        /// </summary>
        public DbSet<UserRole> Roles => Set<UserRole>();
    }
}