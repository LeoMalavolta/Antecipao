using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Infrastructure.Repositories.Empresas;
using Microsoft.Extensions.DependencyInjection;


namespace Antecipacao.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaWriteRepository, EmpresaWriteRepository>();
            services.AddScoped<IEmpresaReadRepository, EmpresaReadRepository>();

            return services;
        }
    }
}
