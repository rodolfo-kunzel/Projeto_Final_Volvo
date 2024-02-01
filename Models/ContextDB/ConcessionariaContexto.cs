using Microsoft.EntityFrameworkCore;


namespace Concessionaria.Models.Context
{
    public class Projeto_Final_Volvo : DbContext
    {
        public DbSet<MCaminhao> Caminhoes {get; set;}
        public DbSet<MCliente> Clientes {get; set;}
        public DbSet<MConcessionaria>  Concessionarias {get; set;}
        public DbSet<MEndereco> Enderecos {get; set;}
        public DbSet<MModeloCaminhao> ModeloCaminhoes {get; set;}
        public DbSet<MMontadora> Montadoras {get; set;}
        public DbSet<MPedido> Pedidos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=;Database=ProjetoFinalDB;User Id=SA;Password=MyPass@word;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<MCaminhao>(entity =>
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

            modelBuilder.Entity<MCliente>(entity =>
            {
                entity.HasMany(c => c.Pedidos)
                    .WithOne(p => p.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MConcessionaria>(entity =>
            {
                entity.HasMany(cc => cc.Caminhoes)
                    .WithOne(c => c.Concessionaria)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MModeloCaminhao>(entity =>
            {
                entity.HasMany(m => m.Caminhoes)
                    .WithOne(c => c.Modelo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MMontadora>(entity =>
            {
                entity.HasMany(mt => mt.Caminhoes)
                    .WithOne(c => c.Montadora)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}