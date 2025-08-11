using Aeropuerto.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using static System.Console;

var builder = WebApplication.CreateBuilder(args);

// Configuración de controladores y salida en XML
builder.Services.AddControllers(options =>
{
    WriteLine("Default output formatters:");
    foreach (IOutputFormatter formatter in options.OutputFormatters)
    {
        if (formatter is OutputFormatter mediaFormatter)
        {
            WriteLine("  {0}, Media types: {1}",
                mediaFormatter.GetType().Name,
                string.Join(", ", mediaFormatter.SupportedMediaTypes));
        }
        else
        {
            WriteLine($"  {formatter.GetType().Name}");
        }
    }
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

// Configuración del contexto de base de datos
builder.Services.AddDbContext<AeropuertoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de CORS para permitir llamadas desde Blazor WebApp
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:port") // ← Cambia esto al puerto correcto de tu Blazor WebApp
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger/OpenAPI para desarrollo
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de seguridad y controladores
app.UseHttpsRedirection();
app.UseCors(); // CORS debe ir antes de Authorization
app.UseAuthorization();
app.MapControllers();

app.Run();
