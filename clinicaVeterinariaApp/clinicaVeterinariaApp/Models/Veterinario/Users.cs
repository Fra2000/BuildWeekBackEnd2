using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Veterinario
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsersID { get; set; }
        [Required,MaxLength(50)]
        public string NomeUser { get; set; }
        [Required,MaxLength(50)]
        public string CognomeUser { get; set; }
       
        [Required,EmailAddress,MaxLength(256)]
        public string Email { get; set; }
        [Required,MaxLength(50)]
        public string PasswordHash { get; set; }
        public string RuoloID { get; set; }
        public Ruoli ruoli { get; set; }

        

    }
}
