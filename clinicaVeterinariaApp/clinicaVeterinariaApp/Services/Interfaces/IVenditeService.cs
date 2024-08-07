using clinicaVeterinariaApp.Models.Farmacia;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IVenditeService
    {
        public Task<IEnumerable<Vendita>> GetAllVendite();
        public Task<IEnumerable<Prodotto>> GetAllProdotti();
        public Task<IEnumerable<Cliente>> GetAllClienti();
        public Task CreateVendita(Vendita vendita);
        public Task DeleteVenditeCall(int venditaId);
        public Task ModificaVend(Vendita V);
    }
}
