using Antecipacao.Application.FaturamentosMensal.Commands.Criar;
using Antecipacao.Application.NotasFiscal.Commands.Alterar;
using Antecipacao.Application.NotasFiscal.Commands.Criar;
using Antecipacao.Application.NotasFiscal.Commands.Excluir;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Antecipação_de_Recebível.Controllers.NotasFiscal
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {

        private readonly ILogger<NotaFiscalController> _logger;
        private readonly IMediator _mediator;

        public NotaFiscalController(ILogger<NotaFiscalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] CriarNotaFiscalCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Alterar([FromBody] AlterarNotaFiscalCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Excluir([FromBody] ExcluirNotaFiscalCommand command, CancellationToken cancellationToken)
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
