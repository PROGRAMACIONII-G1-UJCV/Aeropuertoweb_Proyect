using System.Net.Http.Json;
using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public class BoletoService(HttpClient http) : IBoletoService
{
    public async Task<List<Boleto>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Boleto>>("api/Boleto") ?? [];
    }

    public async Task<Boleto?> GetByIdAsync(int id)
    {
        return await http.GetFromJsonAsync<Boleto>($"api/Boleto/{id}");
    }

    public async Task<bool> CreateAsync(Boleto boleto)
    {
        var response = await http.PostAsJsonAsync("api/Boleto", boleto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Boleto boleto)
    {
        var response = await http.PutAsJsonAsync($"api/Boleto/{boleto.IdBoleto}", boleto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await http.DeleteAsync($"api/Boleto/{id}");
        return response.IsSuccessStatusCode;
    }
}