using System.Net.Http.Json;
using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public class PasajeroService(HttpClient http) : IPasajeroService
{
    public async Task<List<Pasajero>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Pasajero>>("api/Pasajero") ?? new();
    }

    public async Task<Pasajero?> GetByIdAsync(int id)
    {
        return await http.GetFromJsonAsync<Pasajero>($"api/Pasajero/{id}");
    }

    public async Task<bool> CreateAsync(Pasajero pasajero)
    {
        var response = await http.PostAsJsonAsync("api/Pasajero", pasajero);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Pasajero pasajero)
    {
        var response = await http.PutAsJsonAsync($"api/Pasajero/{pasajero.IdPasajero}", pasajero);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await http.DeleteAsync($"api/Pasajero/{id}");
        return response.IsSuccessStatusCode;
    }
}