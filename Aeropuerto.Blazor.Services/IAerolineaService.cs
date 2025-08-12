using Aeropuerto.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto.Blazor.Services
{
    internal interface IAerolineaService
    {
        Task<List<Aerolinea>> GetAllAsync();
        Task<Aerolinea?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Aerolinea aerolinea);
        Task<bool> UpdateAsync(Aerolinea aerolinea);
        Task<bool> DeleteAsync(int id);

    }
}
