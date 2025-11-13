using Antecipação_de_Recebível.Setup;
using Microsoft.AspNetCore.Mvc;

namespace Antecipação_de_Recebível.Extensions
{
    public static class SharedInfrastructureExtensions
    {
        public static WebApplicationBuilder AddSharedInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddProblemDetails();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            builder.Services.AddApiConfig(builder.Configuration);

            //builder.Services.AddAspnetOpenApi();

            //builder.Services.AddCustomVersioning();

            builder.Services.AddHttpContextAccessor();

            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            return builder;
        }
    }
}
