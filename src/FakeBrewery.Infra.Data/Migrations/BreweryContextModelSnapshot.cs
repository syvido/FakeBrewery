﻿// <auto-generated />
using System;
using FakeBrewery.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeBrewery.Infra.Data.Migrations
{
    [DbContext(typeof(BreweryContext))]
    partial class BreweryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeBrewery.Domain.Models.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BreweryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceWithoutVat")
                        .HasColumnType("float");

                    b.Property<double>("Strength")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("FakeBrewery.Domain.Models.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd876cae-ff5b-429d-970b-11af42900f1b"),
                            Name = "Abbaye de Leffe"
                        },
                        new
                        {
                            Id = new Guid("91bff65f-96f2-4bd1-8b2e-eeaef2b46555"),
                            Name = "Abbaye d'Orval"
                        },
                        new
                        {
                            Id = new Guid("a5a1d759-7471-431e-92c0-0f40c35bc855"),
                            Name = "Abbaye de Westmalle"
                        },
                        new
                        {
                            Id = new Guid("d661055d-5c38-4201-b937-79b1b5d77f8f"),
                            Name = "Brasserie Bosteels"
                        });
                });

            modelBuilder.Entity("FakeBrewery.Domain.Models.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("WholesalerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("FakeBrewery.Domain.Models.Wholesaler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28cade6d-4d40-4fa2-96f5-e535a07aad7b"),
                            Name = "BeerLovers' Shop"
                        },
                        new
                        {
                            Id = new Guid("9779f2fa-6f60-4fa9-9b18-28fb2505be6e"),
                            Name = "Beer Market"
                        });
                });

            modelBuilder.Entity("FakeBrewery.Domain.Models.Beer", b =>
                {
                    b.HasOne("FakeBrewery.Domain.Models.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FakeBrewery.Domain.Models.Stock", b =>
                {
                    b.HasOne("FakeBrewery.Domain.Models.Beer", "Beer")
                        .WithMany("Stocks")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FakeBrewery.Domain.Models.Wholesaler", "Wholesaler")
                        .WithMany("Stocks")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
