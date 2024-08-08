namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class RicoveriViewModel
    {
        public int RicoveriID { get; set; }
        public string Tipologia { get; set; }
        public DateTime Datainizioricovero { get; set; }
        public DateTime DataFineRicovero { get; set; }
        public decimal Costo { get; set; }
        public int AnimaleID { get; set; }
        public string NomeAnimale { get; set; }
        public bool MicrochipBit { get; set; }
        public string MicrochipNumber { get; set; }
    }
}
