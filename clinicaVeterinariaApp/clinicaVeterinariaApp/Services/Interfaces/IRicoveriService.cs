using System.Collections.Generic;
using System.Threading.Tasks;
using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IRicoveriService
    {
        Task<IEnumerable<Ricoveri>> GetAllRicoveriAsync();
        Task<Ricoveri> GetRicoveriByIdAsync(int ricoveriId);
        Task<Ricoveri> CreateRicoveriAsync(Ricoveri ricoveri);
        Task UpdateRicoveriAsync(Ricoveri ricoveri);
        Task DeleteRicoveriAsync(int ricoveriId);
    }
}
