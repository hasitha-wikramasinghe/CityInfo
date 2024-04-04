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
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}