using Antecipacao.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antecipacao.Application.NotasFiscal.Commands.Excluir
{
    public record ExcluirNotaFiscalCommand(Guid id) : IRequest<DomainResponse<bool>>;

}
