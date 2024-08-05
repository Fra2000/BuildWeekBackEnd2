using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Cliente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        [Required, MaxLength(16)]
        public string CodiceFiscale { get; set; }
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        [Required, MaxLength(50)]
        public string Indirizzo { get; set; }
        public ICollection<Vendita> Vendita { get; set; }

    }
}
