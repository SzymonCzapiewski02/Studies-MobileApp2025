using Projekt.Intranet.Models.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Intranet.Models.Sklep
{
    public class Recenzja
    {
        [Key]
        public int IdRecenzji { get; set; }
        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("TattoArtists")]
        public int IdTattoArtists { get; set; }
        public TattoArtists? TattoArtists { get; set; }
        [Range(1, 6)]
        [Required(ErrorMessage = "Podaj ocene pomiedzy 1 - 6")]
        [Display(Name = "Ocena(1-6)")]
        public int Wartosc { get; set; }
        [MaxLength(300)]
        [Display(Name = "Komentarz")]
        public string? Komentarz { get; set; }
        [Required(ErrorMessage = "Data jest wymagana.")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
