﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20240406031600_SeedTutorilCitiesAndPOIs")]
    partial class SeedTutorilCitiesAndPOIs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.28");

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The most awesome city in sri lanka",
                            Name = "Colombo"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Near to colombo, This is like a heart of tuition classes in western province",
                            Name = "Gampaha"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A very cold weather we can have there",
                            Name = "Nuwara eliya"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The one with that big park.",
                            Name = "New York City"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The one with the cathedral that was never really finished.",
                            Name = "Antwerp"
                        },
                        new
                        {
                            Id = 6,
                            Description = "The one with that big tower.",
                            Name = "Paris"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "A temple locate in colombo",
                            Name = "Gangarama temple"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            Description = "A temple with a small hike in Gampaha",
                            Name = "Manelwattha temple"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            Description = "A very cold weather having Botanical garden",
                            Name = "Botanical garden"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 4,
                            Description = "The most visited urban park in the United States.",
                            Name = "Central Park"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 4,
                            Description = "A 102-story skyscraper located in Midtown Manhattan.",
                            Name = "Empire State Building"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 5,
                            Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.",
                            Name = "Cathedral"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 5,
                            Description = "The the finest example of railway architecture in Belgium.",
                            Name = "Antwerp Central Station"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 6,
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.",
                            Name = "Eiffel Tower"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 6,
                            Description = "The world's largest museum.",
                            Name = "The Louvre"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}