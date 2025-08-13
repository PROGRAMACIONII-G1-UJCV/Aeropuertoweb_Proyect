using Aeropuerto.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto.Blazor.Services
{
    public interface IAvionService
    {
        Task<List<Avione>> GetAllAsync();
        Task<Avione?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Avione avion);
        Task<bool> UpdateAsync(Avione avion);
        Task<bool> DeleteAsync(int id);
    }
}
