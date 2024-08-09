using clinicaVeterinariaApp.Models.UserViewModel;
using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IUserService
    {
        ProprietarioViewModel GetProprietarioById(int userId);
        AnimalViewModel GetAnimalById(int animalId);
        IEnumerable<AnimalViewModel> GetAnimalsByProprietarioId(int proprietarioId);
        Task<Proprietario> GetProprietarioByUserIdAsync(int userId);
    }

}
