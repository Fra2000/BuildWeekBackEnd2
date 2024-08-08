using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services
{
    public interface IAnimaliService
    {
        Task<IEnumerable<Animali>> GetAllAnimaliAsync();
        Task<Animali> GetAnimaleByIdAsync(int id);
        Task CreateAnimaleAsync(Animali animale);
        Task UpdateAnimaleAsync(Animali animale);
        Task DeleteAnimaleAsync(int id);
    }
}