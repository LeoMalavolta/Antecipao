using Antecipacao.Application.Empresas.Commands.Criar;
using Antecipacao.Infrastructure;
using Antecipacao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Antecipação_de_Recebível.Setup
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencyInjection();

            services.AddDbContext<AntecipacaoDeRecebiveisDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddExceptionHandler<GlobalExcepetionHandler>();

            return services;
        }
    }
}
