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
            // Cliente -> Reservas (1 - Muchos)
            /*modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdClient)
                OnDelete(DeleteBehavior.Restrict);*/

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Reservation>()
				.HasOne(c => c.Cliente)
				.WithMany()
				.HasForeignKey(c => c.IdClient)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Reservation>()
				.HasOne(c => c.Servico)
				.WithMany()
				.HasForeignKey(c => c.IdService)
				.OnDelete(DeleteBehavior.Cascade);

			/* Servicio -> Reservas (1 - Muchos)
			modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Servico)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.IdService)
                .OnDelete(DeleteBehavior.Restrict); */
		}
    }
}
