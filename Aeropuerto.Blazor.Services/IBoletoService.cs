using Aeropuerto.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto.Blazor.Services
{
    public interface IBoletoService
    {
        Task<List<Boleto>> GetAllAsync();
        Task<Boleto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Boleto boleto);
        Task<bool> UpdateAsync(Boleto boleto);
        Task<bool> DeleteAsync(int id);

    }
}
