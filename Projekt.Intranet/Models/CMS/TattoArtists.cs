using Projekt.Intranet.Models.Sklep;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Intranet.Models.CMS
{
    public class TattoArtists
    {
        [Key]
        public int IdTattoArtists { get; set; }
        [Required(ErrorMessage = "Wprowadz imię")]
        [MaxLength(20)]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwisko")]
        [MaxLength(30)]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }
        [Required(ErrorMessage = "Wprowadz przydomek")]
        [MaxLength(50)]
        [Display(Name = "Przydomek")]
        public required string Przydomek { get; set; }
        [Required(ErrorMessage = "Wprowadz doświadczenie")]
        [Display(Name = "Doświadczenie(lata)")]
        public int LataDoswiatczenia { get; set; }
        [Required(ErrorMessage = "Wprowadz specjalizacje")]
        [MaxLength(100)]
        [Display(Name = "Specjalizacja")]
        public string? Specjalizacja { get; set; }
        [MaxLength(11)]
        [Phone(ErrorMessage = "Nieprawidłowy numer telefonu")]
        [Display(Name = "Numer Telefonu")]
        public string? NumerTelefonu { get; set; }

        [Required(ErrorMessage = "Wprowadz email")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Display(Name = "Email")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Wprowadz numer konta")]
        [MaxLength(26)]
        [MinLength(26)]
        [Display(Name = "Numer konta")]
        public required string NumerKonta { get; set; }

        public ICollection<Rezerwacje> Rezerwacje { get; set; } = new List<Rezerwacje>();
        public ICollection<Tatto> Tatto { get; set; } = new List<Tatto>();
        public ICollection<Galeria> Galeria { get; set; } = new List<Galeria>();
        public ICollection<Recenzja> Recenzja { get; set; } = new List<Recenzja>();
    }
}
