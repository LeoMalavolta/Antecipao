using Antecipacao.Infrastructure;

namespace Antecipação_de_Recebível.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddWriteAplication();
            return services;
        }
    }
}
