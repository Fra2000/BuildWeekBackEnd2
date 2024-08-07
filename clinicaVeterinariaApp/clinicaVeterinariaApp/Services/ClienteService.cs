using System;
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _dbContext;


        public ClienteService (AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        //Creazione Cliente 
        public async Task creazioneClienteAsync(string CodiceFiscale, string Nome, string Indirizzo)
        {
            _dbContext.Add(new Cliente { CodiceFiscale = CodiceFiscale, Indirizzo = Indirizzo, Nome = Nome });
            await _dbContext.SaveChangesAsync();
        }


        //Eliminazione cliente 
        public async Task eliminazioneClienteAsync(int ClienteID)
        {
            var cliente = await _dbContext.Clienti.SingleAsync(c => c.ClienteID == ClienteID);
            _dbContext.Clienti.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }


        //Elenco clienti
        public async Task<IEnumerable<Cliente>> elencoClientiAsync() => await _dbContext.Clienti.ToListAsync();
        

        //Modifica
        public async Task<bool> modificaClienteAsync(int ClienteID, string CodiceFiscale, string Nome, string Indirizzo)
        {
            var cliente = await _dbContext.Clienti.SingleOrDefaultAsync(c => c.ClienteID == ClienteID);

            if (cliente == null)
            {
                return false;
            }

            cliente.CodiceFiscale = CodiceFiscale;
            cliente.Nome = Nome;
            cliente.Indirizzo = Indirizzo;

            _dbContext.Clienti.Update(cliente);
            await _dbContext.SaveChangesAsync();

            return true;
        }



        public async Task<Cliente> getClienteByIdAsync(int id)
        {
            return await _dbContext.Clienti.SingleOrDefaultAsync(c => c.ClienteID == id);


        }





    }
}



