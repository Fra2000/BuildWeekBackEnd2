using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Cassetto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CassettoID { get; set; }
        [Required]
        public int NumeroCassetto { get; set; }
        [ForeignKey("Armadio")]
        public int ArmadioID { get; set; }
        public Armadio Armadio { get; set; }
        public ICollection<Medicinale> Medicinale { get; set; }
    }
}
