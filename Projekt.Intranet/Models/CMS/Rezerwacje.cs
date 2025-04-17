using Projekt.Intranet.Models.Sklep;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Intranet.Models.CMS
{
    public class Rezerwacje
    {
        [Key]
        public int IdRezerwacja { get; set; }

        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("TattoArtists")]
        public int IdTattoArtists { get; set; }
        public TattoArtists? TattoArtists { get; set; }

        [Required(ErrorMessage = "Data jest wymagana.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Rezerwacji")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Godzina")]
        public TimeSpan Godzina { get; set; }

        [MaxLength(400)]
        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        public ICollection<Platnosc> Platnosc { get; set; } = new List<Platnosc>();
    }
}
