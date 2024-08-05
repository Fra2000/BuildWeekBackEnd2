using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Fornitore
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FornitoreId { get; set; }
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        [Required, MaxLength(20)]
        public string Recapito { get; set; }
        [Required, MaxLength(256)]
        public string Indirizzo { get; set; }
        public ICollection<Prodotto> Prodotti { get; set; }
    }
}
