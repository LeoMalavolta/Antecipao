using Antecipacao.Domain.Entities;

namespace Antecipacao.Domain.Interfaces.Empresas
{
    public interface IEmpresaWriteRepository : IWriteRepository<Empresa>
    {
        Task<Empresa> ObterEmpresaComCarrinho(Guid id);
        Task<decimal> ObterLimite(Guid id);
        Task<bool> EmpresaJaCadastrada(string cnpj, Guid id);
        Task<Empresa> ObterEmpresaComFaturamento(Guid id);

    }
}
