using Aplicacion.UnitOfWork;
using Dominio.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Puestico.Extensions;
    public static class ApplicationsServiceExtension
    {
       public static void ConfigureCors(this IServiceCollection services) =>
       services.AddCors(options =>
       {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
       });
       public static void AddAplicacionServices(this IServiceCollection services)
       {
        services.AddScoped<IUnidad_trabajo, Unidad_trabajo>();
       }
    }
