using System;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
	public class ProprietarioModel
	{
        [Key]
        public int ProprietarioID { get; set; }


        [Display(Name = "Codice Fiscale"), Required(ErrorMessage = "Inserisci il tuo codice fiscale "), MaxLength(16)]
        public required string Codicefiscale { get; set; }


        [Display(Name = "Nome"), Required(ErrorMessage = "Inserisci il tuo Nome "), MaxLength(50)]
        public required string Nome { get; set; }


        [Display(Name = "Cognome"), Required(ErrorMessage = "Inserisci il tuo Cognome "), MaxLength(256)]
        public required string Cognome { get; set; }

        [Display(Name = "data di nascita "), Required(ErrorMessage = "Inserisci la tua data di nascita  ")]
        public required DateTime DataNascita { get; set; }
    }
}

