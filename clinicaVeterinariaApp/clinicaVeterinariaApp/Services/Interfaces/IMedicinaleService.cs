using clinicaVeterinariaApp.Models.Farmacia;

namespace clinicaVeterinariaApp.Services.Interfaces
{
    public interface IMedicinaleService
    {
        public  Task CreateMedicinali(Medicinale medicinale);
        public  Task<IEnumerable<Cassetto>> GetAllCassetti();
        public Task<IEnumerable<Prodotto>> GetAllProdotti();
        public Task<IEnumerable<Medicinale>> TuttiMedicinali();
        public Task DeleteMedicinaleCall(int medicinaleId);
        public Task ModificaMed(Medicinale M);
    }
}
