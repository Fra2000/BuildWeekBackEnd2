namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class ContabilizzazioneRicoveroViewModel
    {
        public int ContabilizzazioneID { get; set; }
        public int RicoveroID { get; set; }
        public string NomeAnimale { get; set; }
        public DateTime Datainizioricovero { get; set; }
        public DateTime DataContabilizzazione { get; set; }
        public decimal Importo { get; set; }
    }
}
