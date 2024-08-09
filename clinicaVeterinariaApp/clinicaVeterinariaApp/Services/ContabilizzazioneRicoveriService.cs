using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Services.Interfaces;

namespace clinicaVeterinariaApp.Services
{
    public class ContabilizzazioneRicoveriService : IContabilizzazioneRicoveriService
    {
        private readonly AppDbContext _context;

        public ContabilizzazioneRicoveriService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContabilizzazioneRicoveri>> GetAllContabilizzazioniAsync()
        {
            return await _context.ContabilizzazioneRicoveri
                .Include(cr => cr.Ricoveri)
                .ThenInclude(r => r.Animali)
                .ToListAsync();
        }

        public async Task<ContabilizzazioneRicoveri> GetContabilizzazioneByIdAsync(int contabilizzazioneId)
        {
            return await _context.ContabilizzazioneRicoveri
                .Include(cr => cr.Ricoveri)
                .ThenInclude(r => r.Animali)
                .FirstOrDefaultAsync(cr => cr.ContabilizzazioneID == contabilizzazioneId);
        }

        public async Task<ContabilizzazioneRicoveri> CreateContabilizzazioneAsync(ContabilizzazioneRicoveri contabilizzazione)
        {
            _context.ContabilizzazioneRicoveri.Add(contabilizzazione);
            await _context.SaveChangesAsync();
            return contabilizzazione;
        }

        public async Task UpdateContabilizzazioneAsync(ContabilizzazioneRicoveri contabilizzazione)
        {
            _context.Entry(contabilizzazione).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContabilizzazioneAsync(int contabilizzazioneId)
        {
            var contabilizzazione = await _context.ContabilizzazioneRicoveri.FindAsync(contabilizzazioneId);
            if (contabilizzazione != null)
            {
                _context.ContabilizzazioneRicoveri.Remove(contabilizzazione);
                await _context.SaveChangesAsync();
            }
        }
    }
}
