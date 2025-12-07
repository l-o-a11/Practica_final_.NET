using Microsoft.EntityFrameworkCore;
using PracticaFinal.Models;

namespace PracticaFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Usar el constructor principal simplificado con la expresión '=>'
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DECIMAL PRECISION
            modelBuilder.Entity<Servicios>()
            .Property(s => s.Precio)
            .HasColumnType("decimal(18,2)");

            // RELACIÓN: Cliente 1 -> N Reservas
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdClient)
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIÓN: Servicio 1 -> N Reservas
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Servicio) // <-- Corregido: era 'Servico'
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.IdService)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
