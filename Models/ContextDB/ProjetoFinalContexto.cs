using Microsoft.EntityFrameworkCore;

namespace Projeto_Final_Volvo
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
            optionsBuilder.UseSqlServer(@"Server=localhost, 1433;Database=HotelDb;User Id=SA;Password=MyPass@word;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}