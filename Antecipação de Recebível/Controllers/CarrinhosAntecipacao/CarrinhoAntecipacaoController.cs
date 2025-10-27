using Antecipacao.Application.CarrinhosAntecipacao.Commands.AdicionarNota;
using Antecipacao.Application.CarrinhosAntecipacao.Commands.Checkout;
using Antecipacao.Application.CarrinhosAntecipacao.Commands.RemoverNota;
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

        [HttpPost("adicionar-nota")]
        public async Task<ActionResult> AdicionarNota([FromBody] AdicionarNotaCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para adicionar nota {idNota} no carrinho da empresa nota com Id {idEmpresa}", command.idNota, command.idEmpresa);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("Nota adicionada com sucesso. StatusCode: {StatusCode}", result.StatusCode);

            return Ok(result);
        }

        [HttpDelete("remover-nota")]
        public async Task<ActionResult> RemoverNota([FromBody] RemoverNotaCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para remover nota {idNota} no carrinho da empresa nota com Id {idEmpresa}", command.idNota, command.idEmpresa);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("Nota removida com sucesso. StatusCode: {StatusCode}", result.StatusCode);

            return Ok(result);
        }

        [HttpPut("checkout")]
        public async Task<ActionResult> Checkout([FromBody] CheckoutCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para fazer checkout da empresa nota com Id {idEmpresa}", command.idEmpresa);

            var result = await _mediator.Send(command, cancellationToken);

            _logger.LogInformation("Checkout realizado com sucesso. StatusCode: {StatusCode}", result.StatusCode);

            return Ok(result);
        }
    }
}