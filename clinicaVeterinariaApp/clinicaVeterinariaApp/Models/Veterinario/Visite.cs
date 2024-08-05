using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class Visite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitaID { get; set; }
        [Required]
        public int AnimaleID { get; set;}
        public DateTime DataVisita { get; set;}
        [Required]
        public string EsameObiettivo { get; set;}
        [Required]
        public string DescrizioneCura { get; set;}
        public Animali Animale { get; set;}

    }
}
