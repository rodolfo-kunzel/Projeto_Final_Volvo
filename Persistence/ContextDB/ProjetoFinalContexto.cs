using Domain;
using Microsoft.EntityFrameworkCore;


namespace Persistence.ContextDB
{
    public class ProjetoFinalDBContext : DbContext
    {
        public ProjetoFinalDBContext(DbContextOptions<ProjetoFinalDBContext> options) : base(options) { }
        public DbSet<Caminhao> Caminhoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Concessionaria> Concessionarias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ModeloCaminhao> ModeloCaminhoes { get; set; }
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Faturamento> Faturamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Caminhao>(entity =>
            {
                entity.HasIndex(c => c.NumeroChassi).IsUnique();
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
                entity.HasIndex(c => c.NumeroDocumento).IsUnique();
                entity.HasMany(c => c.Pedidos)
                    .WithOne(p => p.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Concessionaria>(entity =>
            {
                entity.HasIndex(cc => cc.CNPJ).IsUnique();
                entity.HasMany(cc => cc.Caminhoes)
                    .WithOne(c => c.Concessionaria)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(cc => cc.Faturamento)
                    .WithOne(f => f.Concessionaria)
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
                entity.HasIndex(mt => mt.CNPJ).IsUnique();
                entity.HasMany(mt => mt.Caminhoes)
                    .WithOne(c => c.Montadora)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(mt => mt.Faturamento)
                    .WithOne(f => f.Montadora)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Faturamento>(entity =>
            {
                entity.HasOne(f => f.Concessionaria)
                    .WithOne(cc => cc.Faturamento)
                    .HasForeignKey<Faturamento>(f => f.ConcessionariaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(f => f.Montadora)
                    .WithOne(mt => mt.Faturamento)
                    .HasForeignKey<Faturamento>(f => f.MontadoraId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasMany(f => f.Pedidos);
            });
        }
    }
}