using System.Collections.Generic;
using System.Threading.Tasks;
using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IContabilizzazioneRicoveriService
    {
        Task<IEnumerable<ContabilizzazioneRicoveri>> GetAllContabilizzazioniAsync();
        Task<ContabilizzazioneRicoveri> GetContabilizzazioneByIdAsync(int contabilizzazioneId);
        Task<ContabilizzazioneRicoveri> CreateContabilizzazioneAsync(ContabilizzazioneRicoveri contabilizzazione);
        Task UpdateContabilizzazioneAsync(ContabilizzazioneRicoveri contabilizzazione);
        Task DeleteContabilizzazioneAsync(int contabilizzazioneId);
    }
}
