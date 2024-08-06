using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Prodotto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdottoID { get; set; }
        [Required, MaxLength(50)]
        public string Nome { get; set; }
        public string FotoProdotto { get; set; }
        [Required, MaxLength(500)]
        public string ElencoUsi { get; set; }
        [Required, MaxLength(20)]
        public decimal PrezzoUnitario { get; set; }

        public Fornitore Fornitore { get; set; }

        public ICollection<Vendita> Vendita { get; set; }
        public ICollection<Medicinale> Medicinale { get; set; }

    }
}
