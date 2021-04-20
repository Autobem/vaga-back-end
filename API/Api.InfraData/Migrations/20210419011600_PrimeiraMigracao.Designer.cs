﻿// <auto-generated />
using System;
using Api.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfraData.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210419011600_PrimeiraMigracao")]
    partial class PrimeiraMigracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Atualizacao")
                        .HasColumnName("atualizacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("cidade")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("Criacao")
                        .HasColumnName("criacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnName("documento")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnName("uf")
                        .HasColumnType("char(2)")
                        .IsFixedLength(true)
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .HasName("ID01_Pessoa");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Api.Domain.Entities.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<short>("Ano")
                        .HasColumnName("ano")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("Atualizacao")
                        .HasColumnName("atualizacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Cambio")
                        .HasColumnName("cambio")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<DateTime>("Criacao")
                        .HasColumnName("criacao")
                        .HasColumnType("datetime");

                    b.Property<int?>("Km")
                        .HasColumnName("km")
                        .HasColumnType("int");

                    b.Property<short>("Modelo")
                        .HasColumnName("modelo")
                        .HasColumnType("smallint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("PessoaId")
                        .HasColumnName("pessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnName("placa")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<byte?>("Portas")
                        .HasColumnName("portas")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Ano")
                        .HasName("ID01_Veiculo");

                    b.HasIndex("Modelo")
                        .HasName("ID03_Veiculo");

                    b.HasIndex("PessoaId");

                    b.HasIndex("Placa")
                        .HasName("ID02_Veiculo");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Api.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("Api.Domain.Entities.Pessoa", "Pessoa")
                        .WithMany("Veiculo")
                        .HasForeignKey("PessoaId")
                        .HasConstraintName("FK_Veiculo_Pessoa")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
