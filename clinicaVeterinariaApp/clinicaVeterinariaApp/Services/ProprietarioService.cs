using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly AppDbContext _dbContext;

        public ProprietarioService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        //Gestione token proprietario 
        public async Task<string> GenerateUniqueTokenAsync()
        {
            string token;
            bool isUnique;

            do
            {
                token = Guid.NewGuid().ToString();
                isUnique = !await _dbContext.Proprietari.AnyAsync(p => p.PrenotazioneToken == token);
            } while (!isUnique);

            return token;
        }


        // Creazione
        public async Task creazioneProprietarioAsync(Proprietario p)
        {
            var token = await GenerateUniqueTokenAsync();
            p.PrenotazioneToken = token; 

            _dbContext.Proprietari.Add(p);
            await _dbContext.SaveChangesAsync();
        }

        //ELENCO Proprietari
        public async Task<IEnumerable<Proprietario>> elencoProprietariAsync() => await _dbContext.Proprietari.ToListAsync();
        

        //Eliminazione 
        public async Task eliminazioneProprietarioAsync(int ProprietarioID)
        {
            var proprietario = await _dbContext.Proprietari.SingleOrDefaultAsync(p => p.ProprietarioID == ProprietarioID);
            _dbContext.Proprietari.Remove(proprietario);
            await _dbContext.SaveChangesAsync();
        }


        //Modifica
        public async Task<Proprietario> getProprietarioByIdAsync(int id)
        {
            return await _dbContext.Proprietari.SingleOrDefaultAsync(p => p.ProprietarioID == id);
        }

        public async Task<bool> modificaProprietarioAsync(int ProprietarioID, string CodiceFiscale, string Nome, string Cognome, DateTime DataNascita)
        {
            var proprietario = await _dbContext.Proprietari.SingleOrDefaultAsync(p => p.ProprietarioID == ProprietarioID);
            if (proprietario == null )
            {
                return false; 
            }

            proprietario.Nome = Nome;
            proprietario.Cognome = Cognome;
            proprietario.Codicefiscale = CodiceFiscale;
            proprietario.DataNascita = DataNascita;

            _dbContext.Proprietari.Update(proprietario);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Proprietario>> GetAllProprietariAsync()
        {
            return await _dbContext.Proprietari.ToListAsync();
        }
    }
}

