using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Users> AuthenticateAsync(string email, string password);
        Task RegisterAsync(string nomeUser, string cognomeUser, string email, string password, int ruoloID);
    }
}
