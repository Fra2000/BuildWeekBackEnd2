using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class Animali
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimaleID { get; set; }

        [Required, MaxLength(50)]
        public string NomeAnimale { get; set; }

        [Required, MaxLength(50)]
        public string Tipologia { get; set; }

        [Required, MaxLength(50)]
        public string ColoreMantello { get; set; }

        public string? FotoAnimale { get; set; } // Cambiato a nullable

        public DateTime? DataNascita { get; set; }

        [Required]
        public bool MicrochipBit { get; set; } = false;

        public string? MicrochipNumber { get; set; }

        public DateTime? Dataregistrazione { get; set; }

        [Required]
        public int ProprietarioID { get; set; }

        public Proprietario Proprietario { get; set; }
        public ICollection<Visite> Visite { get; set; }
        public ICollection<Ricoveri> Ricoveri { get; set; }
    }
}
