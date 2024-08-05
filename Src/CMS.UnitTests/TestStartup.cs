using CMS.AppSettings;
using CMS.Context;
using CMS.Repository;
using CMS.Services;
using CMS.Services.DeserializeService;
using CMS.Services.FileSystemService;
using CMS.ServicesManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.UnitTests
{
    public class TestStartup : IDisposable
    {
        private readonly IServiceScope scope;

        public TestStartup()
        {
            var serviceCollection = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettingsForTests.json", true, true).Build();

            var appSettingsService = new AppSettingsConfig(configuration);

            serviceCollection.AddSingleton<IAppSettingsConfig>(appSettingsService);

            serviceCollection.AddScoped<IDeserializeService, DeserializeService>();

            serviceCollection.AddScoped<IFileSystemService, FileSystemService>();

            var serviceManager = new ServicesManager.ServicesManager();

            serviceCollection.AddScoped<IServicesManager>(_ => serviceManager);

            var domainContext = new DomainContext(serviceManager, appSettingsService);

            var repository = new Repository.Repository(domainContext);

            serviceCollection.AddScoped<IRepository>(_ => repository);

            var homeService = new HomeService(repository);

            serviceCollection.AddScoped<IHomeService>(_ => homeService);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            this.scope = serviceProvider.CreateScope();
        }

        public T GetService<T>() where T : notnull
        {
            return this.scope.ServiceProvider.GetRequiredService<T>();
        }

        public void Dispose()
        {
            this.scope.Dispose();
        }
    }
}
