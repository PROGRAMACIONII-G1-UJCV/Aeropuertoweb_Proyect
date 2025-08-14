using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public interface IMantenimientoService
{
    Task<List<Mantenimiento>> GetAllAsync();
    Task<Mantenimiento?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Mantenimiento mantenimiento);
    Task<bool> UpdateAsync(Mantenimiento mantenimiento);
    Task<bool> DeleteAsync(int id);
}