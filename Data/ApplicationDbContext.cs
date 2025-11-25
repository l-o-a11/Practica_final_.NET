using Microsoft.EntityFrameworkCore;
using PracticaFinal.Models;

namespace PracticaFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
<<<<<<< HEAD
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
=======
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
>>>>>>> 1d3d461e5a031d97463806b2aa9b4037c578fc43
