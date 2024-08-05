using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinicaVeterinariaApp.Models.Farmacia
{
    public class Medicinale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicinaleId { get; set; }
        public Prodotto prodotto { get; set; }
        public Cassetto Cassetto { get; set; }

    }
}
