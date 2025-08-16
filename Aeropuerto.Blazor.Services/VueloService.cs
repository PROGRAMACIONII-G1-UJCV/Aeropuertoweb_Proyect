using Aeropuerto.Blazor.Services;
using Aeropuerto.EntityModels;
using System.Net;
using System.Net.Http.Json;

public class VueloService : IVueloService
{
    private readonly HttpClient _http;
    public VueloService(HttpClient http) => _http = http;

    public async Task<List<Vuelo>> GetAllAsync()
        => await _http.GetFromJsonAsync<List<Vuelo>>("api/Vuelo") ?? new();

    public async Task<Vuelo?> GetByIdAsync(int id)
    {
        var resp = await _http.GetAsync($"api/Vuelo/{id}");
        if (resp.StatusCode == HttpStatusCode.NotFound) return null;
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<Vuelo>();
    }

    public async Task<bool> CreateAsync(Vuelo vuelo)
    {
        var resp = await _http.PostAsJsonAsync("api/Vuelo", vuelo);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Vuelo vuelo)
    {
        var resp = await _http.PutAsJsonAsync($"api/Vuelo/{vuelo.IdVuelo}", vuelo);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var resp = await _http.DeleteAsync($"api/Vuelo/{id}"); // <- SINGULAR, opción B que dijiste te funcionó
        var body = await resp.Content.ReadAsStringAsync();

        Console.WriteLine($"[VueloService] DELETE api/Vuelo/{id} => {(int)resp.StatusCode} {resp.ReasonPhrase} | {body}");

        return resp.IsSuccessStatusCode; // 204/200 = true
    }


}
