using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class Ruoli
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RuoliID { get; set; }
        [Required,StringLength(50)]
        public string NomeRuolo { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
