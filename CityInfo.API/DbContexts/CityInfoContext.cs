using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                new City("Colombo")
                {
                    Id = 1,
                    Description = "The most awesome city in sri lanka"
                },
                new City("Gampaha")
                {
                    Id = 2,
                    Description = "Near to colombo, This is like a heart of tuition classes in western province"
                },
                new City("Nuwara eliya")
                {
                    Id = 3,
                    Description = "A very cold weather we can have there"
                },
                new City("New York City")
                {
                    Id = 4,
                    Description = "The one with that big park."
                },
               new City("Antwerp")
               {
                   Id = 5,
                   Description = "The one with the cathedral that was never really finished."
               },
               new City("Paris")
               {
                   Id = 6,
                   Description = "The one with that big tower."
               });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Gangarama temple")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "A temple locate in colombo"
                },
                new PointOfInterest("Manelwattha temple")
                {
                    Id = 2,
                    CityId = 2,
                    Description = "A temple with a small hike in Gampaha"
                },
                new PointOfInterest("Botanical garden")
                {
                    Id = 3,
                    CityId = 3,
                    Description = "A very cold weather having Botanical garden"
                }, new PointOfInterest("Central Park")
                {
                    Id = 9,
                    CityId = 4,
                    Description = "The most visited urban park in the United States."
                },
               new PointOfInterest("Empire State Building")
               {
                   Id = 10,
                   CityId = 4,
                   Description = "A 102-story skyscraper located in Midtown Manhattan."
               },
                 new PointOfInterest("Cathedral")
                 {
                     Id = 11,
                     CityId = 5,
                     Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                 },
               new PointOfInterest("Antwerp Central Station")
               {
                   Id = 12,
                   CityId = 5,
                   Description = "The the finest example of railway architecture in Belgium."
               },
               new PointOfInterest("Eiffel Tower")
               {
                   Id = 13,
                   CityId = 6,
                   Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
               },
               new PointOfInterest("The Louvre")
               {
                   Id = 14,
                   CityId = 6,
                   Description = "The world's largest museum."
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}