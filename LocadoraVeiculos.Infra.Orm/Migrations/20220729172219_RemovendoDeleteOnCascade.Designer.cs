﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraVeiculosDbContext))]
    [Migration("20220729172219_RemovendoDeleteOnCascade")]
    partial class RemovendoDeleteOnCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocacaoTaxas", b =>
                {
                    b.Property<Guid>("ListaTaxasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocacoesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ListaTaxasId", "LocacoesId");

                    b.HasIndex("LocacoesId");

                    b.ToTable("LocacaoTaxas");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TB_CLIENTE");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCondutores.Condutores", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ValidadeCnh")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TB_CONDUTORES");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdmicao")
                        .HasColumnType("datetime");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoPerfil")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TB_FUNCIONARIOS");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeGrupo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_GRUPOVEICULOS");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondutoresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEstimadaDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRealDaDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NivelTanqueEnumDevolucao")
                        .HasColumnType("int");

                    b.Property<int>("NivelTanqueEnumInicio")
                        .HasColumnType("int");

                    b.Property<Guid>("PlanoCobrancaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("QuilometragemFinal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuilometragemInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("StatusDevolucao")
                        .HasColumnType("bit");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutoresId");

                    b.HasIndex("GrupoVeiculosId");

                    b.HasIndex("PlanoCobrancaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TB_LOCACAO");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("LimiteKM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoPlano")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("ValorDia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorKM")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TB_PLANOCOBRANCA");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloTaxas.Taxas", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TB_TAXAS");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CapacidadeTanque")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Quilometragem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoCombustivel")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TB_VEICULO");
                });

            modelBuilder.Entity("LocacaoTaxas", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloTaxas.Taxas", null)
                        .WithMany()
                        .HasForeignKey("ListaTaxasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany()
                        .HasForeignKey("LocacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloCondutores.Condutores", "Condutores")
                        .WithMany()
                        .HasForeignKey("CondutoresId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", "PlanoCobranca")
                        .WithMany()
                        .HasForeignKey("PlanoCobrancaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Condutores");

                    b.Navigation("GrupoVeiculos");

                    b.Navigation("PlanoCobranca");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
