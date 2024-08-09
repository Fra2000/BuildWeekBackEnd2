namespace clinicaVeterinariaApp.Models.UserViewModel
{
    public class HospitalizationViewModel
    {
        public int HospitalizationId { get; set; }
        public string Tipologia { get; set; }
        public DateTime DataInizioRicovero { get; set; }
        public DateTime DataFineRicovero { get; set; }
        public decimal Costo { get; set; }
        public bool Attivo { get; set; }
    }

}
