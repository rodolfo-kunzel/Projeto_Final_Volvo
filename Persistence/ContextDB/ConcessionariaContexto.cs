using Domain;
using Microsoft.EntityFrameworkCore;


namespace Persistence.ContextDB
{
    public class Projeto_Final_Volvo : DbContext
    {
        public DbSet<Caminhao> Caminhoes {get; set;}
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Concessionaria> Concessionarias {get; set;}
        public DbSet<Endereco> Enderecos {get; set;}
        public DbSet<ModeloCaminhao> ModeloCaminhoes {get; set;}
        public DbSet<Montadora> Montadoras {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=;Database=ProjetoFinalDB;User Id=SA;Password=MyPass@word;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Caminhao>(entity =>
            {
                entity.HasOne(c => c.Modelo)
                    .WithMany(m => m.Caminhoes)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(c => c.Montadora)
                    .WithMany(mt => mt.Caminhoes)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(c => c.Concessionaria)
                    .WithMany(cc => cc.Caminhoes)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasMany(c => c.Pedidos)
                    .WithOne(p => p.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Concessionaria>(entity =>
            {
                entity.HasMany(cc => cc.Caminhoes)
                    .WithOne(c => c.Concessionaria)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ModeloCaminhao>(entity =>
            {
                entity.HasMany(m => m.Caminhoes)
                    .WithOne(c => c.Modelo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Montadora>(entity =>
            {
                entity.HasMany(mt => mt.Caminhoes)
                    .WithOne(c => c.Montadora)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}