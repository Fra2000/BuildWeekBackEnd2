using clinicaVeterinariaApp.Models.Farmacia;


namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IProdottoService
    {
        Task<IEnumerable<Prodotto>> GetAllProdotti();
        Task<Prodotto> GetProdottoById(int id);
        Task<Prodotto> CreateProdotto(Prodotto prodotto);
        Task<Prodotto> UpdateProdotto(int id, Prodotto prodotto);
        Task<bool> DeleteProdotto(int id);
    }
}

