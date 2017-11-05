﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SgConAPI.EntityFramework;
using System;

namespace SgConAPI.Migrations
{
    [DbContext(typeof(SgConContext))]
    [Migration("20171104222922_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("SgConAPI.Models.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<string>("Cnpj")
                        .IsRequired();

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("CriadoPor")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<DateTime?>("ExcluidoEm");

                    b.Property<int>("NumPredios");

                    b.HasKey("Id");

                    b.ToTable("Condominio");
                });

            modelBuilder.Entity("SgConAPI.Models.Predio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<int>("CondominioId");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("CriadoPor")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<DateTime?>("ExcluidoEm");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Predio");
                });

            modelBuilder.Entity("SgConAPI.Models.Predio", b =>
                {
                    b.HasOne("SgConAPI.Models.Condominio", "Condominio")
                        .WithMany("Predios")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
