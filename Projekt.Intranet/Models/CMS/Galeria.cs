using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Intranet.Models.CMS
{
    public class Galeria
    {
        [Key]
        public int IdGaleria { get; set; }
        [ForeignKey("TattoArtists")]
        public int IdTattoArtists { get; set; }
        public TattoArtists? TattoArtists { get; set; }
        [Display(Name = "Url Zdjecia")]
        public string? UrlZdjecia { get; set; }
    }
}
