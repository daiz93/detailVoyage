﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProduitAPI.Data;

#nullable disable

namespace ProduitAPI.Migrations
{
    [DbContext(typeof(ProduitDbContext))]
    [Migration("20231114191029_ProduitModel")]
    partial class ProduitModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ProduitAPI.Models.Produit", b =>
                {
                    b.Property<int>("ProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Actif")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fabricant")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Prix")
                        .HasColumnType("TEXT");

                    b.HasKey("ProduitId");

                    b.ToTable("Produits");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Produit");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProduitAPI.Models.Hotel", b =>
                {
                    b.HasBaseType("ProduitAPI.Models.Produit");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NombreEtoiles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
