using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class Ricoveri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RicoveriID { get; set; }
       
        [Required, MaxLength(50)]
        public string Tipologia { get; set; }
        [Required]
        public DateTime Datainizioricovero { get; set; }
        [Required]
        public DateTime DataFineRicovero { get; set; }
        [Required]
        public int AnimaleID { get; set; }
  
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        [DisplayName("Price ($)")]
        public decimal Costo {  get; set; }
        [Required]
        public bool Attivo {  get; set; }=false;
        public string FotoBase64 { get; set; }
        public Animali Animali { get; set; }


    }
}
