using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public interface IPasajeroService
{
    Task<List<Pasajero>> GetAllAsync();
    Task<Pasajero?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Pasajero pasajero);
    Task<bool> UpdateAsync(Pasajero pasajero);
    Task<bool> DeleteAsync(int id);
}