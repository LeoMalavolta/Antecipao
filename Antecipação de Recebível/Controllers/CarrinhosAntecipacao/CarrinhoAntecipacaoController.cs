using Antecipacao.Application.CarrinhosAntecipacao.Commands.AdicionarNota;
using Antecipacao.Application.CarrinhosAntecipacao.Commands.Checkout;
using Antecipacao.Application.CarrinhosAntecipacao.Commands.RemoverNota;
using Antecipacao.Application.Empresas.Commands.Criar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Antecipação_de_Recebível.Controllers.CarrinhosAntecipacao
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoAntecipacaoController : ControllerBase
    {

        private readonly ILogger<CarrinhoAntecipacaoController> _logger;
        private readonly IMediator _mediator;

        public CarrinhoAntecipacaoController(ILogger<CarrinhoAntecipacaoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPut("adicionar-nota")]
        public async Task<ActionResult> AdicionarNota([FromBody] AdicionarNotaCommand command, CancellationToken cancellationToken)
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

        [HttpPut("remover-nota")]
        public async Task<ActionResult> RemoverNota([FromBody] RemoverNotaCommand command, CancellationToken cancellationToken)
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

        [HttpPut("checkout")]
        public async Task<ActionResult> Checkout([FromBody] CheckoutCommand command, CancellationToken cancellationToken)
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