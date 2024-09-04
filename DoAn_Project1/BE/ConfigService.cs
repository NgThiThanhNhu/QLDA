using AutoDependencyRegistration;
using AutoMapper;
using Repository;
using System.Reflection;
using Entity.DBContent;

namespace BE
{
    public static class ConfigService
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //MAPPER
            var allREPONSITORY = Assembly.GetEntryAssembly()
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(x => x.FullName.Contains("Service"));
            var mappigConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(allREPONSITORY);
                mc.CreateMap<DateOnly?, DateTime?>().ConvertUsing(new DateTimeTypeConverter());
                mc.CreateMap<DateTime?, DateOnly?>().ConvertUsing(new DateOnlyTypeConverter());
            });
            IMapper mapper = mappigConfig.CreateMapper();
            services.AddSingleton(mapper);

            //SQL SERVER
            services.AddTransient<IUnitOfWork, UnitOfWork<DoAnProject1Context>>();
            services.AutoRegisterDependencies();
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateOnly?, DateTime?>
    {
        public DateTime? Convert(DateOnly? source, DateTime? destination, ResolutionContext context)
        {
            return source.HasValue ? source.Value.ToDateTime(TimeOnly.Parse("00:00:00")) : null;
        }
    }

    public class DateOnlyTypeConverter : ITypeConverter<DateTime?, DateOnly?>
    {
        public DateOnly? Convert(DateTime? source, DateOnly? destination, ResolutionContext context)
        {
            return source.HasValue ? DateOnly.FromDateTime(source.Value) : null;
        }
    }
}
