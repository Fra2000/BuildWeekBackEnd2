using System;
using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;

namespace clinicaVeterinariaApp.Models.Farmacia
{
	public class ClienteModel
	{

        [Key]
        public int ClienteID { get; set; }


        [Display(Name = "Codice Fiscale"), Required (ErrorMessage = "Inserisci il tuo codice fiscale "), MaxLength(16)]
		public required string CodiceFiscale { get; set; }


        [Display(Name = "Nome"), Required(ErrorMessage = "Inserisci il tuo Nome "), MaxLength(50)]
        public required string Nome { get; set; }


        [Display(Name = "Indirizzo"), Required(ErrorMessage = "Inserisci il tuo Indirizzo "), MaxLength(50)]
        public required string Indirizzo { get; set; }

    }
}

