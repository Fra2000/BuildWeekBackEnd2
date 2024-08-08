using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clinicaVeterinariaApp.Services
{
    public class VisiteService : IVisiteService
    {
        private readonly AppDbContext _context;

        public VisiteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visite>> GetAllAsync()
        {
            return await _context.Visite.Include(v => v.Animale).ToListAsync();
        }

        public async Task<Visite> GetByIdAsync(int id)
        {
            return await _context.Visite.Include(v => v.Animale).FirstOrDefaultAsync(v => v.VisitaID == id);
        }

        public async Task AddAsync(Visite visite)
        {
            _context.Visite.Add(visite);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Visite visite)
        {
            _context.Entry(visite).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var visite = await _context.Visite.FindAsync(id);
            if (visite != null)
            {
                _context.Visite.Remove(visite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
