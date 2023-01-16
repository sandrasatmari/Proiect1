﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect1.Data;

#nullable disable

namespace Proiect1.Migrations
{
    [DbContext(typeof(Proiect1Context))]
    [Migration("20230115104054_CompanieZbor")]
    partial class CompanieZbor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect1.Models.Aeroport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume_Aeroport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Aeroport");
                });

            modelBuilder.Entity("Proiect1.Models.CompanieAeriana", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CallCenter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume_Airline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CompanieAeriana");
                });

            modelBuilder.Entity("Proiect1.Models.CompanieZbor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompanieAerianaID")
                        .HasColumnType("int");

                    b.Property<int?>("ZborID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanieAerianaID");

                    b.HasIndex("ZborID");

                    b.ToTable("CompanieZbor");
                });

            modelBuilder.Entity("Proiect1.Models.Zbor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AeroportID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPlecare")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Destinatie")
                        .HasColumnType("int");

                    b.Property<int>("NrLocuri")
                        .HasColumnType("int");

                    b.Property<int>("NrLocuriRezervate")
                        .HasColumnType("int");

                    b.Property<int>("OreIntarziere")
                        .HasColumnType("int");

                    b.Property<int>("Poarta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AeroportID");

                    b.ToTable("Zbor");
                });

            modelBuilder.Entity("Proiect1.Models.CompanieZbor", b =>
                {
                    b.HasOne("Proiect1.Models.CompanieAeriana", "CompanieAeriana")
                        .WithMany("CompaniiZbor")
                        .HasForeignKey("CompanieAerianaID");

                    b.HasOne("Proiect1.Models.Zbor", "Zbor")
                        .WithMany("CompaniiZbor")
                        .HasForeignKey("ZborID");

                    b.Navigation("CompanieAeriana");

                    b.Navigation("Zbor");
                });

            modelBuilder.Entity("Proiect1.Models.Zbor", b =>
                {
                    b.HasOne("Proiect1.Models.Aeroport", "Aeroport")
                        .WithMany("Zboruri")
                        .HasForeignKey("AeroportID");

                    b.Navigation("Aeroport");
                });

            modelBuilder.Entity("Proiect1.Models.Aeroport", b =>
                {
                    b.Navigation("Zboruri");
                });

            modelBuilder.Entity("Proiect1.Models.CompanieAeriana", b =>
                {
                    b.Navigation("CompaniiZbor");
                });

            modelBuilder.Entity("Proiect1.Models.Zbor", b =>
                {
                    b.Navigation("CompaniiZbor");
                });
#pragma warning restore 612, 618
        }
    }
}
