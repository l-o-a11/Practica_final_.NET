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
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            // Servicio -> Reservas (1 - Muchos)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Servico)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.IdService)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
