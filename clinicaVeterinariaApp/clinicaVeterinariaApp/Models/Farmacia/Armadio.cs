using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Armadio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArmadioID { get; set; }
       
        [Required, MaxLength(50)]
        public string CodiceUnivoco { get; set; }

        public ICollection<Cassetto> Cassetto { get; set; }


    }
}
