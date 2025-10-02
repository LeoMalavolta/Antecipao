using Antecipacao.Domain.Interfaces.CarrinhosAntecipacao;
using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Domain.Interfaces.FaturamentosMensal;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using Antecipacao.Infrastructure.Repositories.CarrinhosAntecipacao;
using Antecipacao.Infrastructure.Repositories.Empresas;
using Antecipacao.Infrastructure.Repositories.FaturamentosMensal;
using Antecipacao.Infrastructure.Repositories.NotasFiscal;
using Microsoft.Extensions.DependencyInjection;


namespace Antecipacao.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaWriteRepository, EmpresaWriteRepository>();
            services.AddScoped<IEmpresaReadRepository, EmpresaReadRepository>();

            services.AddScoped<IFaturamentoMensalWriteRepository, FaturamentoMensalWriteRepository>();
            services.AddScoped<INotaFiscalWriteRepository, NotaFiscalWriteRepository>();
            services.AddScoped<ICarrinhoAntecipacaoWriteRepository, CarrinhoAntecipacaoWriteRepository>();

            return services;
        }
    }
}
