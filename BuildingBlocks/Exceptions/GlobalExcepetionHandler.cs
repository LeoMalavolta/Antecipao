using BuildingBlocks.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Antecipação_de_Recebível.Setup
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var (statusCode, message, errors) = exception switch
            {
                BaseAppException appEx => (appEx.StatusCode, appEx.Message, appEx.Errors),
                _ => (StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado no servidor.", null)
            };

            _logger.LogError(exception, "ERRO: {mensagem}", message);

            var response = new
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
                Errors = errors
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
