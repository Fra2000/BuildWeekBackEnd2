using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Models.Veterinario;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services
{
    public class ProvaService
    {
        private readonly AppDbContext _context;

        public ProvaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proprietario>> GetAllProprietariAsync()
        {
            return await _context.Proprietari.ToListAsync();
        }
    }
}
