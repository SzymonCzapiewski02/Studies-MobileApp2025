using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Intranet.Models.CMS
{
    public class Platnosc
    {
        [Key]
        public int IdPlatnosc { get; set; }

        [ForeignKey("Rezerwacja")]
        public int IdRezerwacja { get; set; }
        public Rezerwacje? Rezerwacja { get; set; }

        [Required]
        [Display(Name = "Kwota")]
        public decimal Kwota { get; set; }

        [Required(ErrorMessage = "Data jest wymagana.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data płatności")]
        public DateTime Data { get; set; }

        [MaxLength(20)]
        [Display(Name = "Metoda płatności")]
        public string? MetodaPlatnosci { get; set; }
    }
}
