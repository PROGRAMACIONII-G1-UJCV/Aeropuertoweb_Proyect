using Aeropuerto.EntityModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AeropuertoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS para permitir llamadas desde el cliente Blazor
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7122") // Cambia al puerto de tu Blazor WebApp
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger para desarrollo
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

// Usar CORS antes de autorización y mapeo de controladores
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
