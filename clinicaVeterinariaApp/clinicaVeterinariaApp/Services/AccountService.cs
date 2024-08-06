using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;

public class AccountService : IAccountService
{
    private readonly AppDbContext _context;

    public AccountService(AppDbContext context)
    {
        _context = context;
    }

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

    private bool VerifyPasswordHash(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
