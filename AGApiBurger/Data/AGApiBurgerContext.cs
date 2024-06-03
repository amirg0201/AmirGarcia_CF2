using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AmirGarcia_EjercicioCF.Models;

namespace AGApiBurger.Data
{
    public class AGApiBurgerContext : DbContext
    {
        public AGApiBurgerContext (DbContextOptions<AGApiBurgerContext> options)
            : base(options)
        {
        }

        public DbSet<AmirGarcia_EjercicioCF.Models.Promo> Promo { get; set; } = default!;
        public DbSet<AmirGarcia_EjercicioCF.Models.Burger> Burger { get; set; } = default!;
    }
}
