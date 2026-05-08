using Microsoft.EntityFrameworkCore;
using Calculato.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICIOS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Leer la conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"DEBUG: La cadena leída es: {(string.IsNullOrEmpty(connectionString) ? "VACÍA" : "ENCONTRADA")}");

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // 🚀 Esto hace que acepte Mayúsculas (TotalPagado)
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// 2. SINCRONIZACIÓN DE BASE DE DATOS PROFESIONAL
using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Console.WriteLine("DEBUG: Aplicando cambios pendientes en la base de datos...");

        // 🚀 CAMBIO CLAVE: Migrate() sí sabe agregar tablas nuevas a una base de datos existente
        context.Database.Migrate();

        Console.WriteLine("✅ ¡BASE DE DATOS ACTUALIZADA Y TABLAS LISTAS!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ ERROR AL ACTUALIZAR BD: {ex.Message}");
    }
}

// 3. PIPELINE
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();