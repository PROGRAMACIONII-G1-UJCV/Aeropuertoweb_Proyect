using System.Net.Http.Json;
using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public class EquipajeService(HttpClient http) : IEquipajeService
{
    public async Task<List<Equipaje>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Equipaje>>("api/Equipaje") ?? new();
    }

    public async Task<Equipaje?> GetByIdAsync(int id)
    {
        return await http.GetFromJsonAsync<Equipaje>($"api/Equipaje/{id}");
    }

    public async Task<bool> CreateAsync(Equipaje equipaje)
    {
        var response = await http.PostAsJsonAsync("api/Equipaje", equipaje);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Equipaje equipaje)
    {
        var response = await http.PutAsJsonAsync($"api/Equipaje/{equipaje.IdEquipaje}", equipaje);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await http.DeleteAsync($"api/Equipaje/{id}");
        return response.IsSuccessStatusCode;
    }
}