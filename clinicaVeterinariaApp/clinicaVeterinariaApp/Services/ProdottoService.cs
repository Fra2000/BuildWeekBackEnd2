using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace clinicaVeterinariaApp.Services
{
    public class ProdottoService : IProdottoService
    {
        private readonly AppDbContext _context;

        public ProdottoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prodotto>> GetAllProdotti()
        {
            return await _context.Prodotti.Include(p => p.Fornitore).ToListAsync();
        }

        public async Task<Prodotto> GetProdottoById(int id)
        {
            return await _context.Prodotti.Include(p => p.Fornitore)
                                           .FirstOrDefaultAsync(p => p.ProdottoID == id);
        }

        public async Task<Prodotto> CreateProdotto(Prodotto prodotto)
        {
            _context.Prodotti.Add(prodotto);
            await _context.SaveChangesAsync();
            return prodotto;
        }

        public async Task<Prodotto> UpdateProdotto(int id, Prodotto prodotto)
        {
            var existingProdotto = await _context.Prodotti.FindAsync(id);
            if (existingProdotto == null)
            {
                return null;
            }

            existingProdotto.Nome = prodotto.Nome;
            existingProdotto.FotoProdotto = prodotto.FotoProdotto;
            existingProdotto.ElencoUsi = prodotto.ElencoUsi;
            existingProdotto.PrezzoUnitario = prodotto.PrezzoUnitario;
            existingProdotto.Fornitore = prodotto.Fornitore;

            _context.Prodotti.Update(existingProdotto);
            await _context.SaveChangesAsync();

            return existingProdotto;
        }

        public async Task<bool> DeleteProdotto(int id)
        {
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return false;
            }

            _context.Prodotti.Remove(prodotto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
