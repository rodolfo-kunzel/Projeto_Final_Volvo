﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.ContextDB;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ProjetoFinalDBContext))]
    partial class ProjetoFinalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Caminhao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConcessionariaId")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<int>("MontadoraId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroChassi")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ConcessionariaId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("MontadoraId");

                    b.HasIndex("NumeroChassi")
                        .IsUnique();

                    b.HasIndex("PedidoId");

                    b.ToTable("Caminhoes");
                });

            modelBuilder.Entity("Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("NumeroDocumento")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Concessionaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int?>("FaturamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.HasIndex("EnderecoId");

                    b.ToTable("Concessionarias");
                });

            modelBuilder.Entity("Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Domain.Faturamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConcessionariaId")
                        .HasColumnType("int");

                    b.Property<int?>("MontadoraId")
                        .HasColumnType("int");

                    b.Property<double>("ValorFatura")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ConcessionariaId")
                        .IsUnique();

                    b.HasIndex("MontadoraId")
                        .IsUnique()
                        .HasFilter("[MontadoraId] IS NOT NULL");

                    b.ToTable("Faturamento");
                });

            modelBuilder.Entity("Domain.ModeloCaminhao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cabine")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Eixo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Tanque")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Transmissao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ModeloCaminhoes");
                });

            modelBuilder.Entity("Domain.Montadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<double>("Comissao")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int?>("FaturamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.HasIndex("EnderecoId");

                    b.ToTable("Montadoras");
                });

            modelBuilder.Entity("Domain.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Domain.Caminhao", b =>
                {
                    b.HasOne("Domain.Concessionaria", "Concessionaria")
                        .WithMany("Caminhoes")
                        .HasForeignKey("ConcessionariaId")
                        .IsRequired();

                    b.HasOne("Domain.ModeloCaminhao", "Modelo")
                        .WithMany("Caminhoes")
                        .HasForeignKey("ModeloId")
                        .IsRequired();

                    b.HasOne("Domain.Montadora", "Montadora")
                        .WithMany("Caminhoes")
                        .HasForeignKey("MontadoraId")
                        .IsRequired();

                    b.HasOne("Domain.Pedido", "Pedido")
                        .WithMany("Caminhoes")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Concessionaria");

                    b.Navigation("Modelo");

                    b.Navigation("Montadora");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Domain.Cliente", b =>
                {
                    b.HasOne("Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Domain.Concessionaria", b =>
                {
                    b.HasOne("Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Domain.Faturamento", b =>
                {
                    b.HasOne("Domain.Concessionaria", "Concessionaria")
                        .WithOne("Faturamento")
                        .HasForeignKey("Domain.Faturamento", "ConcessionariaId");

                    b.HasOne("Domain.Montadora", "Montadora")
                        .WithOne("Faturamento")
                        .HasForeignKey("Domain.Faturamento", "MontadoraId");

                    b.Navigation("Concessionaria");

                    b.Navigation("Montadora");
                });

            modelBuilder.Entity("Domain.Montadora", b =>
                {
                    b.HasOne("Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Domain.Pedido", b =>
                {
                    b.HasOne("Domain.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Domain.Concessionaria", b =>
                {
                    b.Navigation("Caminhoes");

                    b.Navigation("Faturamento");
                });

            modelBuilder.Entity("Domain.ModeloCaminhao", b =>
                {
                    b.Navigation("Caminhoes");
                });

            modelBuilder.Entity("Domain.Montadora", b =>
                {
                    b.Navigation("Caminhoes");

                    b.Navigation("Faturamento");
                });

            modelBuilder.Entity("Domain.Pedido", b =>
                {
                    b.Navigation("Caminhoes");
                });
#pragma warning restore 612, 618
        }
    }
}
