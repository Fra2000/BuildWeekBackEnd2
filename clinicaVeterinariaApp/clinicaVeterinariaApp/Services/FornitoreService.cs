using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services
{
	public class FornitoreService : IFornitoreService
	{
        private readonly AppDbContext _dbContext;

        public FornitoreService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }


        //Creazione Fornitore
        public async Task creazioneFornitoreAsync(string Recapito, string Nome, string Indirizzo)
        {
            _dbContext.Add(new Fornitore { Recapito = Recapito, Indirizzo = Indirizzo, Nome = Nome });
            await _dbContext.SaveChangesAsync();
        }


        //Elenco fornitori
        public async Task<IEnumerable<Fornitore>> elencoFornitoriAsync() => await _dbContext.Fornitori.ToListAsync();

       


        //Eliminazione fornitori 
        public async Task eliminazioneFornitoreAsync(int FornitoreId)
        {
            var fornitore = await _dbContext.Fornitori.SingleOrDefaultAsync(f => f.FornitoreId == FornitoreId);

            _dbContext.Fornitori.Remove(fornitore);
            await _dbContext.SaveChangesAsync();


        }



        //MODIFICA FORNITORI 
        public async Task<Fornitore> getFornitoreByIdAsync(int id)
        {
            return await _dbContext.Fornitori.SingleOrDefaultAsync(f => f.FornitoreId == id);
        }

        public async Task<bool> modificaFornitoreAsync(int FornitoreId, string Recapito, string Nome, string Indirizzo)
        {
            var fornitore = await _dbContext.Fornitori.SingleOrDefaultAsync(f => f.FornitoreId == FornitoreId);

            if(fornitore == null)
            {
                return false;
            }

            fornitore.Nome = Nome;
            fornitore.Indirizzo = Indirizzo;
            fornitore.Recapito = Recapito;

            _dbContext.Fornitori.Update(fornitore);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

