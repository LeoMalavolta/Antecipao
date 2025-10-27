using Antecipacao.Application.Empresas.Commands.Criar;
using Antecipacao.Application.FaturamentosMensal.Commands.Alterar;
using Antecipacao.Application.FaturamentosMensal.Commands.Criar;
using Antecipacao.Application.FaturamentosMensal.Commands.Excluir;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Antecipação_de_Recebível.Controllers.FaturamentosMensal
{
    [ApiController]
    [Route("[controller]")]
    public class FaturamentoMensalController : ControllerBase
    {

        private readonly ILogger<FaturamentoMensalController> _logger;
        private readonly IMediator _mediator;

        public FaturamentoMensalController(ILogger<FaturamentoMensalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] CriarFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para criar faturamento mensal da empresa com Id {idEmpresa}", command.idEmpresa);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("Faturamento mensal criado com sucesso. StatusCode: {StatusCode}", result.StatusCode);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Alterar([FromBody] AlterarFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para criar faturamento mensal com Id {idFaturamento}", command.id);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("Faturamento mensal alterado com sucesso. StatusCode: {StatusCode}", result.StatusCode);

            return Ok(result);
        }

        [HttpDelete("excluir")]
        public async Task<ActionResult> Excluir([FromBody] ExcluirFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para excluir faturamento mensal com Id {idFaturamento}", command.id);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("Faturamento mensal excluido com sucesso. StatusCode: {StatusCode}", result.StatusCode);

            return Ok(result);
        }
    }
}