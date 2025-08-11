using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aeropuerto.EntityModels; // Para registrar el namespace
using ModeloAeropuerto = Aeropuerto.EntityModels.Aeropuerto; // Alias para evitar conflicto

namespace Aeropuerto.Blazor.Services
{
    public class AeropuertoService
    {
        private readonly HttpClient _http;

        public AeropuertoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ModeloAeropuerto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<ModeloAeropuerto>>("api/aeropuerto");
        }

        public async Task DeleteAsync(int id)
        {
            await _http.DeleteAsync($"api/aeropuerto/{id}");
        }
    }
}
