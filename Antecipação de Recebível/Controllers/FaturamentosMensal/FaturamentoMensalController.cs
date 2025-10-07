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

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Faturamento mensal criado com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Erro ao criar faturamento mensal da empresa com Id {idEmpresa}", command.idEmpresa);
                return BadRequest(
                             new ProblemDetails
                             {
                                 Title = "Erro de validação",
                                 Detail = ex.Message,
                                 Status = StatusCodes.Status400BadRequest
                             });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar faturamento mensal da empresa com Id {idEmpresa}", command.idEmpresa);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Alterar([FromBody] AlterarFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para criar faturamento mensal com Id {idFaturamento}", command.id);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Faturamento mensal alterado com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Erro ao alterar faturamento mensal da empresa com Id {idFaturamento}", command.id);
                return BadRequest(
                             new ProblemDetails
                             {
                                 Title = "Erro de validação",
                                 Detail = ex.Message,
                                 Status = StatusCodes.Status400BadRequest
                             });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar faturamento mensal da empresa com Id {idFaturamento}", command.id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("excluir")]
        public async Task<ActionResult> Excluir([FromBody] ExcluirFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para excluir faturamento mensal com Id {idFaturamento}", command.id);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Faturamento mensal excluido com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir faturamento mensal da empresa com Id {idFaturamento}", command.id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}