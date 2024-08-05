using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Cassetto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CassettoId { get; set; }
        [Required]
        public int NumeroCassetto { get; set; }
        public Armadio armadio { get; set; }
        public ICollection<Medicinale> Medicinale { get; set; }
    }
}
