using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt.Intranet.Models.CMS;

namespace Projekt.Intranet.Data
{
    public class ProjektIntranetContext : DbContext
    {
        public ProjektIntranetContext (DbContextOptions<ProjektIntranetContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt.Intranet.Models.CMS.TattoArtists> TattoArtists { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.CMS.Klient> Klient { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.CMS.Tatto> Tatto { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.CMS.Rezerwacje> Rezerwacje { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.CMS.Galeria> Galeria { get; set; } = default!;
        public DbSet<Platnosc> Platnosc { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.Sklep.Produkt> Produkt { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.Sklep.Recenzja> Recenzja { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.CMS.User> User { get; set; } = default!;
        public DbSet<Projekt.Intranet.Models.Sklep.Zamowienia> Zamowienia { get; set; } = default!;
    }
}
