using System.Net.Http.Json;
using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public class PuertasEmbarqueServices : IPuertasEmbarqueService
{
    private readonly HttpClient _http;

    public PuertasEmbarqueServices(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PuertasEmbarque>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<PuertasEmbarque>>("api/PuertasEmbarque") ?? new();
    }

    public async Task<PuertasEmbarque?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<PuertasEmbarque>($"api/PuertasEmbarque/{id}");
    }

    public async Task<bool> CreateAsync(PuertasEmbarque puerta)
    {
        var response = await _http.PostAsJsonAsync("api/PuertasEmbarque", puerta);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(PuertasEmbarque puerta)
    {
        var response = await _http.PutAsJsonAsync($"api/PuertasEmbarque/{puerta.IdPuerta}", puerta);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/PuertasEmbarque/{id}");
        return response.IsSuccessStatusCode;
    }
}