using System.Net.Http.Json;
using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public class EmpleadoService(HttpClient http) : IEmpleadoService
{
    private readonly HttpClient _http = http;

    public async Task<List<Empleado>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Empleado>>("api/Empleado") ?? [];
    }

    public async Task<Empleado?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Empleado>($"api/Empleado/{id}");
    }

    public async Task<bool> CreateAsync(Empleado empleado)
    {
        var response = await _http.PostAsJsonAsync("api/Empleado", empleado);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Empleado empleado)
    {
        var response = await _http.PutAsJsonAsync($"api/Empleado/{empleado.IdEmpleado}", empleado);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Empleado/{id}");
        return response.IsSuccessStatusCode;
    }
}