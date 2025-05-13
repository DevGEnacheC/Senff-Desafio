using AluguelCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            // Carro
            modelBuilder.Entity<Carro>().HasKey(c => c.Id);
            modelBuilder.Entity<Carro>()
                .HasIndex(c => c.Placa)
                .IsUnique();
            
            // Cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CPF)
                .IsUnique();
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CNH)
                .IsUnique();

            modelBuilder.Entity<Aluguel>().HasKey(a => a.Id);

            // Aluguel
            modelBuilder.Entity<Aluguel>()
                .HasOne<Carro>()
                .WithMany()
                .HasForeignKey(a => a.CarroId);

            modelBuilder.Entity<Aluguel>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(a => a.ClienteId);
        }
    }
}
