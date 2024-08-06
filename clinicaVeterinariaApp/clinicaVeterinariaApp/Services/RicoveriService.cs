using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Services.Interfaces;

namespace clinicaVeterinariaApp.Services
{
    public class RicoveriService : IRicoveriService
    {
        private readonly AppDbContext _context;

        public RicoveriService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ricoveri>> GetAllRicoveriAsync()
        {
            return await _context.Ricoveri
                .Include(r => r.Animali)
                .ToListAsync();
        }

        public async Task<Ricoveri> GetRicoveriByIdAsync(int ricoveriId)
        {
            return await _context.Ricoveri
                .Include(r => r.Animali)
                .FirstOrDefaultAsync(r => r.RicoveriID == ricoveriId);
        }

        public async Task<Ricoveri> CreateRicoveriAsync(Ricoveri ricoveri)
        {
            _context.Ricoveri.Add(ricoveri);
            await _context.SaveChangesAsync();
            return ricoveri;
        }

        public async Task UpdateRicoveriAsync(Ricoveri ricoveri)
        {
            _context.Entry(ricoveri).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRicoveriAsync(int ricoveriId)
        {
            Ricoveri ricoveri = await _context.Ricoveri.FindAsync(ricoveriId);
            if (ricoveri != null)
            {
                _context.Ricoveri.Remove(ricoveri);
                await _context.SaveChangesAsync();
            }
        }
    }
}
