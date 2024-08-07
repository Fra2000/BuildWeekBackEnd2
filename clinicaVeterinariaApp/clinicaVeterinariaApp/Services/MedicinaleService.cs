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

        //***********************************************
        //FUNZIONE CHE FA VEDERE TUTTI I MEDICINALI
        public async Task<IEnumerable<Medicinale>> TuttiMedicinali()
        {
            return await _context
                .Medicinali.Include(m => m.Prodotto)
                .Include(m => m.Cassetto)
                .ThenInclude(c => c.Armadio)
                .ToListAsync();
        }

        //***********************************************
        //FUNZIONE CHE ELIMINA MEDICINALE
        public async Task DeleteMedicinaleCall(int medicinaleId)
        {
            var medicinale = await _context.Medicinali.FindAsync(medicinaleId);

            if (medicinale != null)
            {
                _context.Medicinali.Remove(medicinale);

                await _context.SaveChangesAsync();
            }
        }

        //***********************************************
        //FUNZIONE CHE AGGIORNA IL MEDICINALE
        public async Task ModificaMed(Medicinale M)
        {
            // Trova il medicinale esistente
            var medicinale = await _context.Medicinali.FindAsync(M.MedicinaleID);

            if (medicinale != null)
            {
                // Aggiorna le proprietà
                medicinale.ProdottoID = M.ProdottoID;
                medicinale.CassettoID = M.CassettoID;

                // Salva le modifiche
                await _context.SaveChangesAsync();
            }
        }
    }
}
