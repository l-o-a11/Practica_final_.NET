using PracticaFinal.Model;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Models;

namespace PracticaFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PRECISIÓN DECIMAL
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");

            // RELACIÓN: Cliente 1 -> N Reservas
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIÓN: Servicio 1 -> N Reservas
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Servicio)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            //RELACION: Status 1 -> N Cliente  
            modelBuilder.Entity<Cliente>()
                .HasOne(r => r.Status)
                .WithMany(x => x.Clients)
				.HasForeignKey(r => r.StatusId)
				.OnDelete(DeleteBehavior.NoAction);

			//RELACION: Status 1 -> N Servicio  
			modelBuilder.Entity<Service>()
				.HasOne(r => r.Status)
				.WithMany(y => y.Service)
				.HasForeignKey(r => r.StatusId)
				.OnDelete(DeleteBehavior.NoAction);

			//RELACION: Status 1 -> N Reserva  
			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Status)
				.WithMany(z => z.Reservations)
				.HasForeignKey(r => r.StatusId)
				.OnDelete(DeleteBehavior.NoAction);


		}
    }
}
