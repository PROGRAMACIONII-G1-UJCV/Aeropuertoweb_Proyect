using System.Collections.Generic;
using System.Threading.Tasks;
using Aeropuerto.EntityModels;
using ModeloAeropuerto = Aeropuerto.EntityModels.Aeropuerto;

namespace Aeropuerto.Blazor.Services
{
    public interface IAeropuertoService
    {
        Task<List<ModeloAeropuerto>> GetAllAsync();
        Task<ModeloAeropuerto?> GetByIdAsync(int id);
        Task<ModeloAeropuerto?> CreateAsync(ModeloAeropuerto aeropuerto);
        Task<ModeloAeropuerto?> UpdateAsync(int id, ModeloAeropuerto aeropuerto);
        Task<bool> DeleteAsync(int id);
    }
}
