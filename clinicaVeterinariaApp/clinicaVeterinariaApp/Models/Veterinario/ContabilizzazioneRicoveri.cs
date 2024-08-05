using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class ContabilizzazioneRicoveri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContabilizzazioneID { get; set; }
        public int RicoveroID { get; set; }
        [Required]
        public DateTime DataContabilizzazione { get; set;}
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public Decimal Importo { get; set;}
        public Ricoveri Ricoveri { get; set;}



    }
}
