using clinicaVeterinariaApp.Models.Veterinario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IContabilizzazioneRicoveriService
    {
        Task<IEnumerable<ContabilizzazioneRicoveri>> GetAllAsync();
        Task<ContabilizzazioneRicoveri> GetByIdAsync(int id);
        Task AddAsync(ContabilizzazioneRicoveri contabilizzazione);
        Task UpdateAsync(ContabilizzazioneRicoveri contabilizzazione);
        Task DeleteAsync(int id);
    }
}
