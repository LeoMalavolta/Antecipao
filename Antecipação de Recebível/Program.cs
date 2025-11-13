using Antecipação_de_Recebível.Extensions;
using Antecipação_de_Recebível.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.AddSharedInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
