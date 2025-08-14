using System.Net.Http.Json;
using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public class MantenimientoService(HttpClient http) : IMantenimientoService
{
    public async Task<List<Mantenimiento>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Mantenimiento>>("api/Mantenimiento") ?? new();
    }

    public async Task<Mantenimiento?> GetByIdAsync(int id)
    {
        return await http.GetFromJsonAsync<Mantenimiento>($"api/Mantenimiento/{id}");
    }

    public async Task<bool> CreateAsync(Mantenimiento mantenimiento)
    {
        var response = await http.PostAsJsonAsync("api/Mantenimiento", mantenimiento);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Mantenimiento mantenimiento)
    {
        var response = await http.PutAsJsonAsync($"api/Mantenimiento/{mantenimiento.IdMantenimiento}", mantenimiento);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await http.DeleteAsync($"api/Mantenimiento/{id}");
        return response.IsSuccessStatusCode;
    }
}