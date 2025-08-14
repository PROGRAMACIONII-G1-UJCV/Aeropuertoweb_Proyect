using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public interface IEmpleadoService
{
    Task<List<Empleado>> GetAllAsync();
    Task<Empleado?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Empleado empleado);
    Task<bool> UpdateAsync(Empleado empleado);
    Task<bool> DeleteAsync(int id);
}