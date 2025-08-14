using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public interface IEquipajeService
{
    Task<List<Equipaje>> GetAllAsync();
    Task<Equipaje?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Equipaje equipaje);
    Task<bool> UpdateAsync(Equipaje equipaje);
    Task<bool> DeleteAsync(int id);
}