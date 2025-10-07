using Antecipacao.Application.Empresas.Commands.Alterar;
using Antecipacao.Application.Empresas.Commands.CalcularLimite;
using Antecipacao.Application.Empresas.Commands.Criar;
using Antecipacao.Application.Empresas.Commands.Excluir;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Antecipação_de_Recebível.Controllers.Empresas
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {

        private readonly ILogger<EmpresaController> _logger;
        private readonly IMediator _mediator;

        public EmpresaController(ILogger<EmpresaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] CriarEmpresaCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida requisição para criar empresa com CNPJ {Cnpj}", command.cnpj);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                _logger.LogInformation("Empresa criada com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Erro ao criar empresa com CNPJ {Cnpj}", command.cnpj);
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
                _logger.LogError(ex, "Erro ao criar empresa com CNPJ {Cnpj}", command.cnpj);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Alterar([FromBody] AlterarEmpresaCommand command)
        {
            _logger.LogInformation("Recebida requisição para alterar empresa com CNPJ {Cnpj}", command.cnpj);

            try
            {
                var result = await _mediator.Send(command, HttpContext.RequestAborted);

                _logger.LogInformation("Empresa alterada com sucesso. StatusCode: {StatusCode}", result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Erro ao alterar empresa com CNPJ {Cnpj}", command.cnpj);
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
                _logger.LogError(ex, "Erro ao alterar empresa com CNPJ {Cnpj}", command.cnpj);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("excluir")]
        public async Task<ActionResult> Excluir([FromBody] ExcluirEmpresaCommand command)
        {
            _logger.LogInformation("Recebida requisição para excluir empresa com Id {EmpresaId}", command.id);

            try
            {
                var result = await _mediator.Send(command, HttpContext.RequestAborted);

                _logger.LogInformation("Empresa {EmpresaId} excluída com StatusCode {StatusCode}", command.id, result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir empresa com Id {EmpresaId}", command.id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("atualizar-limite")]
        public async Task<ActionResult> AtualizarLimite([FromBody] CalcularLimiteCommand command)
        {
            _logger.LogInformation("Recebida requisição para atualizar limite da empresa com Id {EmpresaId}", command.id);

            try
            {
                var result = await _mediator.Send(command, HttpContext.RequestAborted);

                _logger.LogInformation("Limite da empresa {EmpresaId} atualizado com sucesso. StatusCode: {StatusCode}", command.id, result.StatusCode);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar limite da empresa com Id {EmpresaId}", command.id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno ao atualizar limite.");
            }
        }
    }
}
