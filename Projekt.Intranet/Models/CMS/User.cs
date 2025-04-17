using System.ComponentModel.DataAnnotations;

namespace Projekt.Intranet.Models.CMS
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Podaj login")]
        [MaxLength(50)]
        public required string Login { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Podaj Hasło")]
        [MaxLength(50)]
        public required string haslo { get; set; }
    }
}
