using Microsoft.EntityFrameworkCore;
using PracticaFinal.Models;

namespace PracticaFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
