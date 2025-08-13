// Services/AerolineaService.cs
using Aeropuerto.Blazor.Services;
using Aeropuerto.EntityModels;
using System.Net.Http.Json;

public class AerolineaService : IAerolineaService

{
    private readonly HttpClient _http;

    public AerolineaService(HttpClient http) => _http = http;

    public async Task<List<Aerolinea>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<Aerolinea>>("api/Aerolinea");

    public async Task<Aerolinea?> GetByIdAsync(int id) =>
        await _http.GetFromJsonAsync<Aerolinea>($"api/Aerolinea/{id}");

    public async Task<bool> CreateAsync(Aerolinea a)
    {
        var resp = await _http.PostAsJsonAsync("api/Aerolinea", a);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Aerolinea a)
    {
        var resp = await _http.PutAsJsonAsync($"api/Aerolinea/{a.IdAerolinea}", a);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var resp = await _http.DeleteAsync($"api/Aerolinea/{id}");
        return resp.IsSuccessStatusCode;
    }
}