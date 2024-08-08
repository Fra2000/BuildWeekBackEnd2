using clinicaVeterinariaApp.Models.Farmacia;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models
{
    public class CreateprodottoViewModel
    {
        
        public int ProdottoID { get; set; }
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        public string FotoProdotto { get; set; }
        [Required, MaxLength(500)]
        public string ElencoUsi { get; set; }
        [Required]
        public decimal PrezzoUnitario { get; set; }

        public int FornitoreId{ get; set; }
    }
}
