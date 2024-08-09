namespace clinicaVeterinariaApp.Models.UserViewModel
{
    public class ProprietarioViewModel
    {
        public int ProprietarioId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string PrenotazioneToken { get; set; }
    }

}
