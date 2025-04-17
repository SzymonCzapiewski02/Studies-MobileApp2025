using Projekt.Intranet.Models.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Intranet.Models.Sklep
{
    public class Zamowienia
    {
        [Key]
        public int IdZamowienia { get; set; }
        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; }
        [ForeignKey("Produkt")]
        public int IdProduktu { get; set; }
        public Produkt? Produkt { get; set; }
    }
}
