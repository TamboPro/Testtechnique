﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProduitAPI.DAL;

#nullable disable

namespace ProduitAPI.Migrations
{
    [DbContext(typeof(ProduitContext))]
    [Migration("20231006014827_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ProduitAPI.Models.Categorie", b =>
                {
                    b.Property<Guid>("IdCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeCategorie")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProduitAPI.Models.Client", b =>
                {
                    b.Property<Guid>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ProduitAPI.Models.Hotel", b =>
                {
                    b.Property<Guid>("IdHotel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Classe")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomHotel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdHotel");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("ProduitAPI.Models.Ligne", b =>
                {
                    b.Property<Guid>("IdLigne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Prix")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProduitId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantite")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("TEXT");

                    b.HasKey("IdLigne");

                    b.HasIndex("ReservationId");

                    b.ToTable("Lignes");
                });

            modelBuilder.Entity("ProduitAPI.Models.Produit", b =>
                {
                    b.Property<Guid>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategorieId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Hotelid")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Prix")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeProduit")
                        .HasColumnType("TEXT");

                    b.HasKey("IdProduit");

                    b.HasIndex("Hotelid");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("ProduitAPI.Models.Reservation", b =>
                {
                    b.Property<Guid>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdReservation");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ProduitAPI.Models.Ligne", b =>
                {
                    b.HasOne("ProduitAPI.Models.Reservation", null)
                        .WithMany("Lignes")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProduitAPI.Models.Produit", b =>
                {
                    b.HasOne("ProduitAPI.Models.Hotel", null)
                        .WithMany("produits")
                        .HasForeignKey("Hotelid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProduitAPI.Models.Hotel", b =>
                {
                    b.Navigation("produits");
                });

            modelBuilder.Entity("ProduitAPI.Models.Reservation", b =>
                {
                    b.Navigation("Lignes");
                });
#pragma warning restore 612, 618
        }
    }
}