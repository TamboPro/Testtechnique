﻿// <auto-generated />
using System;
using ClientAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientAPI.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20231005091432_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ClientAPI.Models.Client", b =>
                {
                    b.Property<Guid>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            IdClient = new Guid("800e8c07-cbab-4e73-9535-9c0df16fdde0"),
                            Adresse = "Yaounde Nkolbisson",
                            DateNaissance = new DateTime(2023, 10, 5, 10, 14, 32, 93, DateTimeKind.Local).AddTicks(4460),
                            Email = "g.nfongyele@gmail.com",
                            Nom = "tambo",
                            Prenom = "Gédéon"
                        },
                        new
                        {
                            IdClient = new Guid("a53ebe29-2923-43f1-b486-f66ec90a89c3"),
                            Adresse = "Douala Logbessou",
                            DateNaissance = new DateTime(2023, 10, 5, 10, 14, 32, 93, DateTimeKind.Local).AddTicks(4473),
                            Email = "innovalab237@gmail.com",
                            Nom = "tambo",
                            Prenom = "Gédéon"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
