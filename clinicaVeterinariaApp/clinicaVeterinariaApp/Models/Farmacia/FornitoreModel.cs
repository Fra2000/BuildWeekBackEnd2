using System;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
	public class FornitoreModel
	{
        [Key]
        public int FornitoreId { get; set; }


        [Display(Name = "Recapito"), Required(ErrorMessage = "Inserisci il tuo recapito "), MaxLength(20)]
        public required string Recapito { get; set; }


        [Display(Name = "Nome"), Required(ErrorMessage = "Inserisci il tuo Nome "), MaxLength(50)]
        public required string Nome { get; set; }


        [Display(Name = "Indirizzo"), Required(ErrorMessage = "Inserisci il tuo Indirizzo "), MaxLength(256)]
        public required string Indirizzo { get; set; }
    }
}

