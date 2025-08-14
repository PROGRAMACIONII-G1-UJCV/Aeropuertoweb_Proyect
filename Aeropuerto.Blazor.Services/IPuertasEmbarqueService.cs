using Aeropuerto.EntityModels;

namespace Aeropuerto.Blazor.Services;

public interface IPuertasEmbarqueService
{
    Task<List<PuertasEmbarque>> GetAllAsync();
    Task<PuertasEmbarque?> GetByIdAsync(int id);
    Task<bool> CreateAsync(PuertasEmbarque puerta);
    Task<bool> UpdateAsync(PuertasEmbarque puerta);
    Task<bool> DeleteAsync(int id);
}