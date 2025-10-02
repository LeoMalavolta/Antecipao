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
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on POST {this.GetType().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Alterar([FromBody] AlterarFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on PUT {this.GetType().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("excluir")]
        public async Task<ActionResult> Excluir([FromBody] ExcluirFaturamentoMensalCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on PUT {this.GetType().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}