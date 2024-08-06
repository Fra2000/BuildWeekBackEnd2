using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services
{
    public class MedicinaleService : IMedicinaleService
    {
        private readonly AppDbContext _context;

        public MedicinaleService(AppDbContext context)
        {
            _context = context;
        }

        //***********************************************
        // FUNZIONI AUSILIARI PER CREARE UN MEDICINALE
        //***********************************************
        // PRENDE TUTTI I CASSETTI

        public async Task<IEnumerable<Cassetto>> GetAllCassetti()
        {
            return await _context.Cassetto.ToListAsync();
        }

        //***********************************************
        //PRENDE TUTTI I PRODOTTI (sono solo medicinali)

        public async Task<IEnumerable<Prodotto>> GetAllProdotti()
        {
            return await _context.Prodotti.ToListAsync();
        }

        //***********************************************
        //FUNZIONE CHE CREA UN MEDICINALE
        public async Task CreateMedicinali(Medicinale medicinale)
        {
            _context.Medicinali.Add(medicinale);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medicinale>> TuttiMedicinali()
        {
            return await _context
                .Medicinali.Include(m => m.Prodotto) // Include la navigazione al Prodotto
                .Include(m => m.Cassetto) // Include la navigazione al Cassetto, se necessario
                .ToListAsync();
        }
    }
}
