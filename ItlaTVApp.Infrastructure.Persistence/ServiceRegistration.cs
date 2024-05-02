using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Infrastructure.Persistence.Contexts;
using ItlaTVApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTVApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductoraRepository, ProductoraRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<ISerieRepository, SerieRepository>();
            #endregion
        }
    }
}
