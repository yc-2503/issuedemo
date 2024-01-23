using Testcontainers.MySql;
using Testcontainers.PostgreSql;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace PESC.Web.Tests;

public class TestContainerFixture : IDisposable
{
    public RedisContainer RedisContainer { get; } =
        new RedisBuilder().Build();

    public RabbitMqContainer RabbitMqContainer { get; } = new RabbitMqBuilder()
        .WithUsername("guest").WithPassword("guest").Build();

    public PostgreSqlContainer PostgreSqlContainer { get; } = new PostgreSqlBuilder()
        .WithUsername("root").WithPassword("123456")
        .WithEnvironment("TZ", "Asia/Shanghai")
        .WithDatabase("palc").Build();

    public TestContainerFixture()
    {
        Task.WhenAll(RedisContainer.StartAsync(),
            RabbitMqContainer.StartAsync(),
            PostgreSqlContainer.StartAsync()).Wait();
    }

    public void Dispose()
    {
        Task.WhenAll(RedisContainer.StopAsync(),
            RabbitMqContainer.StopAsync(),
            PostgreSqlContainer.StopAsync()).Wait();
    }
}