﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarefa.Database;

#nullable disable

namespace Tarefa.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211124050948_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GrupoPessoa", b =>
                {
                    b.Property<Guid>("GruposId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PessoasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GruposId", "PessoasId");

                    b.HasIndex("PessoasId");

                    b.ToTable("GrupoPessoa");
                });

            modelBuilder.Entity("Tarefa.Database.Entities.Autenticacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Autenticacoes");
                });

            modelBuilder.Entity("Tarefa.Database.Entities.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Tarefa.Database.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("GrupoPessoa", b =>
                {
                    b.HasOne("Tarefa.Database.Entities.Grupo", null)
                        .WithMany()
                        .HasForeignKey("GruposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tarefa.Database.Entities.Pessoa", null)
                        .WithMany()
                        .HasForeignKey("PessoasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tarefa.Database.Entities.Autenticacao", b =>
                {
                    b.HasOne("Tarefa.Database.Entities.Grupo", "Grupo")
                        .WithMany("Autenticacoes")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("Tarefa.Database.Entities.Grupo", b =>
                {
                    b.Navigation("Autenticacoes");
                });
#pragma warning restore 612, 618
        }
    }
}