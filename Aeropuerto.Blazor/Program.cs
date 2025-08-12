using Aeropuerto.Blazor.Components;
using Aeropuerto.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IAeropuertoService, AeropuertoService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7163/");


});
builder.Services.AddHttpClient<AerolineaService, AerolineaService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7163/"); // Asegúrate que coincida con tu WebAPI
});




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
