using clinicaVeterinariaApp.Models.Veterinario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IVisiteService
    {
        Task<IEnumerable<Visite>> GetAllAsync();
        Task<Visite> GetByIdAsync(int id);
        Task AddAsync(Visite visite);
        Task UpdateAsync(Visite visite);
        Task DeleteAsync(int id);
        public Task ModificaVisite(Visite visita);
    }
}
