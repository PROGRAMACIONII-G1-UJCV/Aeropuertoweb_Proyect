using Aeropuerto.Blazor.Components;
using Aeropuerto.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IAeropuertoService, AeropuertoService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7163/"); // Ajusta el puerto según tu WebAPI
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
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
