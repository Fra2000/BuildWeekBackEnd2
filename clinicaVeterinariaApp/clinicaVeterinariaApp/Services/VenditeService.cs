using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services
{
    public class VenditeService : IVenditeService
    {
        private readonly AppDbContext _context;

        public VenditeService(AppDbContext context)
        {
            _context = context;
        }
        //***********************************************
        //PRENDE TUTTE LE VENDITE 
        public async Task<IEnumerable<Vendita>> GetAllVendite()
        {
            return await _context
                .Vendite.Include(m => m.Prodotto)
                .Include(m => m.Cliente)
                .ToListAsync(); ;
        }

        //***********************************************
        //PRENDE TUTTE LE VENDITE 
        public async Task<IEnumerable<Prodotto>> GetAllProdotti()
        {
            return await _context.Prodotti.ToListAsync();
        }
        
        //***********************************************
        //PRENDE TUTTI I CLIENTI 
        public async Task<IEnumerable<Cliente>> GetAllClienti()
        {
            return await _context.Clienti.ToListAsync();
        }

        //***********************************************
        //PRENDE TUTTE LE VENDITE 
        public async Task CreateVendita(Vendita vendita)
        {
            _context.Vendite.Add(vendita);
            await _context.SaveChangesAsync();
        }

        //***********************************************
        //ELIMINA LE VENDITE 
        public async Task DeleteVenditeCall(int venditaId)
        {
            var vendita = await _context.Vendite.FindAsync(venditaId);

            if (vendita != null)
            {
                _context.Vendite.Remove(vendita);

                await _context.SaveChangesAsync();
            }
        }


        public async Task ModificaVend(Vendita V)
        {
            // Trova il medicinale esistente
            var vendita = await _context.Vendite.FindAsync(V.VenditaID);

            if (vendita != null)
            {
                // Aggiorna le proprietà
                vendita.ProdottoID = V.ProdottoID;
                vendita.ClienteID = V.ClienteID;
                vendita.Quantita = V.Quantita;
                vendita.StatoVendita = V.StatoVendita;

                // Salva le modifiche
                await _context.SaveChangesAsync();
            }
        }
    }
}
