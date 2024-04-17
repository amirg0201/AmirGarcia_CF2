using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AmirGarcia_EjercicioCF.Models;

namespace AmirGarcia_EjercicioCF.Data
{
    public class AmirGarcia_EjercicioCFContext : DbContext
    {
        public AmirGarcia_EjercicioCFContext (DbContextOptions<AmirGarcia_EjercicioCFContext> options)
            : base(options)
        {
        }

        public DbSet<AmirGarcia_EjercicioCF.Models.Burger> Burger { get; set; } = default!;
        public DbSet<AmirGarcia_EjercicioCF.Models.AG_Promo> Promo { get; set; } = default!;
    }
}
