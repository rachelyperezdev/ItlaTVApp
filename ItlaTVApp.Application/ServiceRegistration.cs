using ItlaTVApp.Core.Application.Interfaces.Services;
using ItlaTVApp.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTVApp.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<IProductoraService, ProductoraService>();
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<ISerieService, SerieService>();
            #endregion
        }
    }
}
