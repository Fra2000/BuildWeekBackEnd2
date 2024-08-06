using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Medicinale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicinaleID { get; set; }
        [ForeignKey("Prodotto")]
        public int ProdottoID { get; set; }
        public Prodotto Prodotto { get; set; }
        [ForeignKey("Cassetto")]
        public int CassettoID { get; set; }
        public Cassetto Cassetto { get; set; }

    }
}
