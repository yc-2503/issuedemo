using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using NetCorePal.Extensions.AspNetCore.Json;

namespace PESC.Web.Tests
{
    public class MyWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly TestContainerFixture _containers = new TestContainerFixture();

        static MyWebApplicationFactory()
        {
            NewtonsoftJsonDefaults.DefaultOptions.Converters.Add(new NewtonsoftEntityIdJsonConverter());
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("ConnectionStrings:Redis", _containers.RedisContainer.GetConnectionString());
            builder.UseSetting("ConnectionStrings:Postgresql", _containers.PostgreSqlContainer.GetConnectionString());
            builder.UseSetting("RabbitMQ:Port", _containers.RabbitMqContainer.GetMappedPublicPort(5672).ToString());
            builder.UseSetting("RabbitMQ:UserName", "guest");
            builder.UseSetting("RabbitMQ:Password", "guest");
            builder.UseSetting("RabbitMQ:VirtualHost", "/");
            builder.UseSetting("RabbitMQ:HostName", _containers.RabbitMqContainer.Hostname);
            builder.UseEnvironment("Development");
            base.ConfigureWebHost(builder);
        }

        public override async ValueTask DisposeAsync()
        {
            try
            {
                await base.DisposeAsync();
            }
            catch
            {
                // ignored
            }

            try
            {
                _containers.Dispose();
            }
            catch
            {
                // ignored
            }
        }
    }
}