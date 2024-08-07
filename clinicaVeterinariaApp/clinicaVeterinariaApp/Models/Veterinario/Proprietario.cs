using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class Proprietario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProprietarioID { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, MaxLength(50)]
        public string Cognome { get; set; }

        [Required]
        public DateTime DataNascita { get; set; }

        [Required]
        public string Codicefiscale { get; set; }

        // Nuovo campo per il token di prenotazione
        public string PrenotazioneToken { get; set; }

        // Nuovo campo UserID
        [ForeignKey("User")]
        public int? UserID { get; set; } // Nullable per gestire i record esistenti

        // Proprietà di navigazione
        public Users User { get; set; }

        public ICollection<Animali> Animali { get; set; }

        public string? PrenotazioneToken { get; set; }
    }
}
