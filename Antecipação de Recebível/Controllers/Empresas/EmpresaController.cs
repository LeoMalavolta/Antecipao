using Antecipacao.Application.Empresas.Commands.Criar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Antecipação_de_Recebível.Controllers.Empresas
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public EmpresaController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] CriarEmpresaCommand commnad)
        {
            try
            {
                var result = await _mediator.Send(commnad, HttpContext.RequestAborted);

                return StatusCode((int)result.StatusCode, result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error on GET {this.GetType().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
