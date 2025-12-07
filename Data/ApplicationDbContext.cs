using Microsoft.EntityFrameworkCore;
using PracticaFinal.Models;

namespace PracticaFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Reservation>()
				.HasOne(c => c.Cliente)
				.WithMany()
				.HasForeignKey(c => c.IdClient)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Reservation>()
				.HasOne(c => c.Servicio)
				.WithMany()
				.HasForeignKey(c => c.IdService)
				.OnDelete(DeleteBehavior.Cascade);

		
		}
    }
}
