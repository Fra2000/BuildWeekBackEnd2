namespace clinicaVeterinariaApp.Models.UserViewModel
{
    public class AnimalViewModel
    {
        public int AnimalId { get; set; }
        public string NomeAnimale { get; set; }
        public string Tipologia { get; set; }
        public string ColoreMantello { get; set; }
        public string? FotoAnimale { get; set; }
        public DateTime? DataNascita { get; set; }
        public bool MicrochipBit { get; set; }
        public string? MicrochipNumber { get; set; }
        public DateTime? DataRegistrazione { get; set; }

        // Nuove proprietà per visite e ricoveri
        public IEnumerable<VisitViewModel> Visite { get; set; }
        public IEnumerable<HospitalizationViewModel> Ricoveri { get; set; }
    }

}
