using AutoMapper;
using CMS.AppSettings;
using CMS.ItemsContainer;
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

            CreateAppSettingsConfig(services);

            //CreateMapper(services);

            services.AddScoped<IServicesManager, ServicesManager.ServicesManager>();

            services.AddScoped<IComponentsContainer, ComponentsContainer>();

            return services;
        }

        private static void CreateAppSettingsConfig(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var appSettingsService = new AppSettingsConfig(configuration);

            services.AddSingleton<IAppSettingsConfig>(appSettingsService);
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
