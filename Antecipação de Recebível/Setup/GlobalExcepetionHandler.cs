using Antecipacao.Domain.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Antecipação_de_Recebível.Setup
{
    public class GlobalExcepetionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExcepetionHandler> _logger;

        public GlobalExcepetionHandler(ILogger<GlobalExcepetionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            (int statusCode, string errorMessage) = exception switch
            {
                ArgumentException argEx => (StatusCodes.Status400BadRequest, argEx.Message),
                DomainException domainEx => (StatusCodes.Status422UnprocessableEntity, domainEx.Message),
                UnauthorizedAccessException unauthEx => (StatusCodes.Status401Unauthorized, unauthEx.Message),
                SqlException sqlEx => (StatusCodes.Status500InternalServerError, "Erro no banco de dados."),
            };

            _logger.LogError(exception, "Erro ao processar a requisição: {Message}", exception.Message);
            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = statusCode,
                Title = "Erro ao processar requisição",
                Detail = errorMessage,
                Instance = httpContext.Request.Path
            }, cancellationToken);

            return true;
        }
    }
}
