﻿// <auto-generated />
using System;
using Carteira.Domain.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carteira.Domain.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200725232329_CalculosCustoMedio")]
    partial class CalculosCustoMedio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Carteira.Domain.Ativo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("TipoInvestimento")
                        .HasColumnType("smallint");

                    b.Property<short>("TipoPapel")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Ativos");
                });

            modelBuilder.Entity("Carteira.Domain.Corretora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Corretoras");
                });

            modelBuilder.Entity("Carteira.Domain.Deposito", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorretoraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SaldoAcumulado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CorretoraId");

                    b.ToTable("Depositos");
                });

            modelBuilder.Entity("Carteira.Domain.Operacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AtivoId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Corretagem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CorretoraId")
                        .HasColumnType("int");

                    b.Property<decimal>("CustoMedio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Emolumentos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoCotas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("TipoOperacao")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AtivoId");

                    b.HasIndex("CorretoraId");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("Carteira.Domain.Deposito", b =>
                {
                    b.HasOne("Carteira.Domain.Corretora", "Corretora")
                        .WithMany("Depositos")
                        .HasForeignKey("CorretoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Carteira.Domain.Operacao", b =>
                {
                    b.HasOne("Carteira.Domain.Ativo", "Ativo")
                        .WithMany("Operacoes")
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Carteira.Domain.Corretora", "Corretora")
                        .WithMany("Operacoes")
                        .HasForeignKey("CorretoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}