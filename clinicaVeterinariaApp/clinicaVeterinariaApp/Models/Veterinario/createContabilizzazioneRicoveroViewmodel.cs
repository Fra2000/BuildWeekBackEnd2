namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class CreateContabilizzazioneRicoveroViewModel
    {
        public ContabilizzazioneRicoveroViewModel ContabilizzazioneRicovero { get; set; }
        public IEnumerable<ContabilizzazioneRicoveroViewModel> RicoveriAttivi { get; set; }
    }
}
