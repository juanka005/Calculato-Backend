using Microsoft.EntityFrameworkCore;
using Calculato.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICIOS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Configuración automática más simple

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. PIPELINE (Interfaz visual)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculato API V1");
        c.RoutePrefix = string.Empty; // Carga Swagger al abrir la URL
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();