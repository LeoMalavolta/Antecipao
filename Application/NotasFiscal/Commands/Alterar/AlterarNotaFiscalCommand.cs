using Antecipacao.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antecipacao.Application.NotasFiscal.Commands.Alterar
{
    public record AlterarNotaFiscalCommand(
        Guid id,
        string numero,
        Decimal valor,
        DateTime dataVencimento) : IRequest<DomainResponse<bool>>;
}