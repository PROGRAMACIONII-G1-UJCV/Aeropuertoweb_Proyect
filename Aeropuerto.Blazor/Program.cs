using Aeropuerto.Blazor.Components;
using Aeropuerto.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7163") 
});


builder.Services.AddHttpClient<AerolineaService, AerolineaService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7163/"); // Asegúrate que coincida con tu WebAPI
});
// Configura HttpClient con la base de la API
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// ✅ REGISTRO DE SERVICIOS PERSONALIZADOS
builder.Services.AddScoped<IAeropuertoService, AeropuertoService>();
builder.Services.AddScoped<IAvionService, AvionService>(); // 
builder.Services.AddScoped<IAerolineaService, AerolineaService>();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IEquipajeService, EquipajeService>();
builder.Services.AddScoped<IMantenimientoService, MantenimientoService>();
builder.Services.AddScoped<IPasajeroService, PasajeroService>();
builder.Services.AddScoped<IPuertasEmbarqueService, PuertasEmbarqueServices>();



builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
