using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using System.Threading.Tasks;

public class AccountService : IAccountService
{
    private readonly AppDbContext _context;

    public AccountService(AppDbContext context)
    {
        _context = context;
    }

    //Gestione Autenticazione 
    public async Task<Users> AuthenticateAsync(string email, string password)
    {
        var user = await _context.Users.Include(u => u.Ruoli)
                                        .SingleOrDefaultAsync(u => u.Email == email);

        if (user != null && VerifyPasswordHash(password, user.PasswordHash))
        {
            return user;
        }

        return null;
    }

    //Gestione Registrazione 
    public async Task RegisterAsync(string nomeUser, string cognomeUser, string email, string password, int ruoloID)
    {
        var hashedPassword = HashPassword(password);

        var user = new Users
        {
            NomeUser = nomeUser,
            CognomeUser = cognomeUser,
            Email = email,
            PasswordHash = hashedPassword,
            RuoloID = ruoloID
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    //Gestione registrazione User con token univoco per associazione user e proprietario
    public async Task RegisterUserAsync(string nomeUser, string cognomeUser, string email, string password, string prenotazioneToken)
    {
        // Verifica il token
        var proprietario = await _context.Proprietari
                                         .SingleOrDefaultAsync(p => p.PrenotazioneToken == prenotazioneToken);

        if (proprietario == null)
        {
            throw new Exception("Invalid token.");
        }

        // Crea un nuovo utente
        var hashedPassword = HashPassword(password);
        var user = new Users
        {
            NomeUser = nomeUser,
            CognomeUser = cognomeUser,
            Email = email,
            PasswordHash = hashedPassword,
            RuoloID = 3 // ID 3 è l'id del ruolo User
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(); // Salva prima l'utente per avere l'ID

        // Associa l'utente al proprietario
        proprietario.UserID = user.UsersID;
        _context.Proprietari.Update(proprietario);

        // Salva le modifiche al proprietario
        await _context.SaveChangesAsync();
    }




    private bool VerifyPasswordHash(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
