using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Infrastructure.Data;
using Antecipacao.Infrastructure.Repositories.Empresas;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AntecipacaoDeRecebiveisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddControllers();


builder.Services.AddScoped<IEmpresaWriteRepository, EmpresaWriteRepository>();
builder.Services.AddScoped<IEmpresaReadRepository, EmpresaReadRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
