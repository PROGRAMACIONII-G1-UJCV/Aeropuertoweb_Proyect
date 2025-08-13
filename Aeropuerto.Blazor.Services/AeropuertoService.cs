using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aeropuerto.EntityModels;
using ModeloAeropuerto = Aeropuerto.EntityModels.Aeropuerto;

namespace Aeropuerto.Blazor.Services
{
    public class AeropuertoService : IAeropuertoService
    {
        private readonly HttpClient _http;

        public AeropuertoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ModeloAeropuerto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<ModeloAeropuerto>>("api/aeropuerto") ?? new();
        }

        public async Task<ModeloAeropuerto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<ModeloAeropuerto>($"api/aeropuerto/{id}");
        }

        public async Task<ModeloAeropuerto?> CreateAsync(ModeloAeropuerto aeropuerto)
        {
            var response = await _http.PostAsJsonAsync("api/aeropuerto", aeropuerto);
            return await response.Content.ReadFromJsonAsync<ModeloAeropuerto>();
        }

        public async Task<ModeloAeropuerto?> UpdateAsync(int id, ModeloAeropuerto aeropuerto)
        {
            var response = await _http.PutAsJsonAsync($"api/aeropuerto/{id}", aeropuerto);
            return await response.Content.ReadFromJsonAsync<ModeloAeropuerto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/aeropuerto/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
