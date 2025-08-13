using Aeropuerto.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto.Blazor.Services
{
    public class AvionService : IAvionService
    {
        private readonly HttpClient _http;

        public AvionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Avione>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Avione>>("api/Avione") ?? new();
        }

        public async Task<Avione?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Avione>($"api/Avione/{id}");
        }

        public async Task<bool> CreateAsync(Avione avion)
        {
            var response = await _http.PostAsJsonAsync("api/Avione", avion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Avione avion)
        {
            var response = await _http.PutAsJsonAsync($"api/Avione/{avion.IdAvion}", avion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Avione/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
