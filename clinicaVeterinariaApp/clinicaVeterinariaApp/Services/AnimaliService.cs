using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services
{
    public class AnimaliService : IAnimaliService
    {
        private readonly AppDbContext _context;

        public AnimaliService(AppDbContext context)
        {
            _context = context;
        }

        //Restituzione di tutti gli animali 
        public async Task<IEnumerable<Animali>> GetAllAnimaliAsync()
        {
            return await _context.Animali.ToListAsync();
        }

        public async Task<Animali> GetAnimaleByIdAsync(int id)
        {
            return await _context.Animali.FindAsync(id);
        }

        //Gestione creazione e salvataggio nuovo animale 
        public async Task CreateAnimaleAsync(Animali animale)
        {
            // Imposta Dataregistrazione alla data corrente se non è già impostata
            if (animale.Dataregistrazione == null)
            {
                animale.Dataregistrazione = DateTime.UtcNow;
            }

            _context.Animali.Add(animale);
            await _context.SaveChangesAsync();
        }

        //Gestione delle modifiche 
        public async Task UpdateAnimaleAsync(Animali animale)
        {
            // Imposta Dataregistrazione alla data corrente se non è già impostata
            if (animale.Dataregistrazione == null)
            {
                animale.Dataregistrazione = DateTime.UtcNow;
            }

            _context.Entry(animale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        //Gestione eliminazion
        public async Task DeleteAnimaleAsync(int id)
        {
            var animale = await _context.Animali.FindAsync(id);
            if (animale != null)
            {
                _context.Animali.Remove(animale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
