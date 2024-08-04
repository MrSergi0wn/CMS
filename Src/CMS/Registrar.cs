using AutoMapper;
using CMS.AppSettings;
using CMS.Context;
using CMS.Repository;
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

            var domainContext = new DomainContext(serviceManager, appSettingsService);

            services.AddScoped<IRepository>(_ => new Repository.Repository(domainContext));

            return services;
        }

        //private static void CreateMapper(this IServiceCollection services)
        //{
        //    var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression =>
        //    {
        //        mapperConfigurationExpression.AddProfile(new MapperProfile());
        //    });

        //    services.AddScoped(provider => provider.GetService<MapperConfiguration>()!.CreateMapper());

        //    services.AddSingleton<IMapper>(new AutoMapper.Mapper(mapperConfiguration));

        //    mapperConfiguration.CreateMapper();
        //}
    }
}
