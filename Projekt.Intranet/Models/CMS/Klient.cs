using Projekt.Intranet.Models.Sklep;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Intranet.Models.CMS
{
    public class Klient
    {
        [Key]
        public int IdKlient { get; set; }

        [Required(ErrorMessage = "Wprowadz imię")]
        [MaxLength(20)]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadz nazwisko")]
        [MaxLength(30)]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [MaxLength(11)]
        [Phone(ErrorMessage = "Nieprawidłowy numer telefonu")]
        [Display(Name = "Numer Telefonu")]
        public string? NumerTelefonu { get; set; }

        [Required(ErrorMessage = "Wprowadz email")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        public ICollection<Rezerwacje> Rezerwacje { get; set; } = new List<Rezerwacje>();
        public ICollection<Tatto> Tatto { get; set; } = new List<Tatto>();
        public ICollection<Zamowienia> Zamowienia { get; set; } = new List<Zamowienia>();
        public ICollection<Recenzja> Recenzja { get; set; } = new List<Recenzja>();
    }
}
