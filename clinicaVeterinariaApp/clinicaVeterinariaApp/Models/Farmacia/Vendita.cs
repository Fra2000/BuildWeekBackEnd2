using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Vendita
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenditaId { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int ProdotttoId { get; set; }
        [Required]

        public DateTime DataVendita { get; set; } = DateTime.Now;
        [Required, MaxLength(50)]
        public string NumeroRicettaMedica { get; set; }
        [Required, Range(1, 20)]
        public int Quantita { get; set; }

        public Cliente Cliente { get; set; }
        public Prodotto Prodotto { get; set; }
    }
}
