using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect1.Models;

namespace Proiect1.Data
{
    public class Proiect1Context : DbContext
    {
        public Proiect1Context (DbContextOptions<Proiect1Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect1.Models.Zbor> Zbor { get; set; } = default!;

        public DbSet<Proiect1.Models.Aeroport> Aeroport { get; set; }

        public DbSet<Proiect1.Models.CompanieAeriana> CompanieAeriana { get; set; }

        public DbSet<Proiect1.Models.CompanieZbor> CompanieZbor { get; set; }

        public DbSet<Proiect1.Models.Poarta> Poarta { get; set; }

        //public DbSet<Proiect1.Models.Member> Member { get; set; }
    }
}
