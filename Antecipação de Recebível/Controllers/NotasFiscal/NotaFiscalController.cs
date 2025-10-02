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
            _logger.LogInformation("Recebida requisição para criar nota fiscal {numero} da empresa com Id {idEmpresa}", command.numero, command.idEmpresa);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Nota fiscal criada com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar nota fiscal {numero} da empresa com Id {idEmpresa}", command.numero, command.idEmpresa);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Alterar([FromBody] AlterarNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para alterar nota fiscal {numero}, nota com Id {idNota}", command.numero, command.id);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Nota fiscal alterada com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar nota fiscal {numero}, nota com Id {idNota}", command.numero, command.id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("excluir")]
        public async Task<ActionResult> Excluir([FromBody] ExcluirNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para excluir nota fiscal, nota com Id {idNota}", command.id);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Nota fiscal excluida com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir nota fiscal, nota com Id {idNota}", command.id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
