using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projFinal.Models;

namespace projFinal.Models
{
    public class projFinalContext : DbContext
    {
        public projFinalContext (DbContextOptions<projFinalContext> options)
            : base(options)
        {
        }

        public DbSet<projFinal.Models.Movie> Movie { get; set; }

        public DbSet<projFinal.Models.User> User { get; set; }

        public DbSet<projFinal.Models.Borrow> Borrow { get; set; }
    }
}
