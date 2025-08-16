using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public interface IVueloService
{
    Task<List<Vuelo>> GetAllAsync();
    Task<Vuelo?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Vuelo vuelo);
    Task<bool> UpdateAsync(Vuelo vuelo);
    Task<bool> DeleteAsync(int id);
}