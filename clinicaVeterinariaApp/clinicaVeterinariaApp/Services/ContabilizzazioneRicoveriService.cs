using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clinicaVeterinariaApp.Services
{
    public class ContabilizzazioneRicoveriService : IContabilizzazioneRicoveriService
    {
        private readonly AppDbContext _context;

        public ContabilizzazioneRicoveriService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContabilizzazioneRicoveri>> GetAllAsync()
        {
            return await _context.ContabilizzazioneRicoveri.Include(c => c.Ricoveri).ToListAsync();
        }

        public async Task<ContabilizzazioneRicoveri> GetByIdAsync(int id)
        {
            return await _context.ContabilizzazioneRicoveri
                                 .Include(c => c.Ricoveri)
                                 .FirstOrDefaultAsync(c => c.ContabilizzazioneID == id);
        }

        public async Task AddAsync(ContabilizzazioneRicoveri contabilizzazione)
        {
            _context.ContabilizzazioneRicoveri.Add(contabilizzazione);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContabilizzazioneRicoveri contabilizzazione)
        {
            _context.Entry(contabilizzazione).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contabilizzazione = await _context.ContabilizzazioneRicoveri.FindAsync(id);
            if (contabilizzazione != null)
            {
                _context.ContabilizzazioneRicoveri.Remove(contabilizzazione);
                await _context.SaveChangesAsync();
            }
        }
    }
}
