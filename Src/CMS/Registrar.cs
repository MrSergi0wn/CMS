using CMS.AppSettings;
using CMS.Context;
using CMS.Repository;
using CMS.Services;
using CMS.ServicesManager;

namespace CMS
{
    public static class Registrar
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddMvc();

            services.AddKendo();

            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy = null);

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var appSettingsService = new AppSettingsConfig(configuration);

            services.AddSingleton<IAppSettingsConfig>(appSettingsService);

            var serviceManager = new ServicesManager.ServicesManager();

            services.AddScoped<IServicesManager>(_ => serviceManager);

            services.AddScoped<IDomainContext, DomainContext>();

            services.AddScoped<IRepository, Repository.Repository>();

            services.AddScoped<IHomeService, HomeService>();

            return services;
        }
    }
}
