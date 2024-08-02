using AutoMapper;
using CMS.AppSettings;
using CMS.Context;
using CMS.ItemsContainer;
using CMS.Repository;
using CMS.ServicesManager;
using Microsoft.Extensions.DependencyInjection;

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

            //CreateMapper(services);

            var serviceManager = new ServicesManager.ServicesManager();

            services.AddScoped<IServicesManager>(service => serviceManager);

            var domainContext = new DomainContext(serviceManager, appSettingsService);

            services.AddScoped<IRepository>(service => new Repository.Repository(domainContext));

            return services;
        }

        private static void CreateAppSettingsConfig(this IServiceCollection services)
        {
            
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
