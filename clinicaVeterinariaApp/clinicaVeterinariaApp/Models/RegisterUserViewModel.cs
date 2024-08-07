namespace clinicaVeterinariaApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string NomeUser { get; set; }

        [Required]
        [Display(Name = "Cognome")]
        public string CognomeUser { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Token")]
        public string PrenotazioneToken { get; set; }
    }

}
