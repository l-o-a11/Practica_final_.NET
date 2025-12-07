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
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PRECISIÓN DECIMAL
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
                .HasOne(r => r.Servicios)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.IdService)
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIÓN MANY-TO-MANY (UserRoles)
            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.userRols)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.userRols)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
