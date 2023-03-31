using ChaveAutenticidadeSelos.Services.Interfaces;

namespace ChaveAutenticidadeSelos.Services

{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)  
        {
            services.AddScoped<IChaveAutenticidadeService, ChaveAutenticidadeService>();
            services.AddScoped<IExtrairInformacoes, ExtrairInformacoes>();

            return services;
        }
    }
}