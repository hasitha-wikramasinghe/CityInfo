﻿using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            // dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Ja Ela",
                    Description = "Some description abt ja ela",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Royal Hotel",
                            Description = "Some desc about royal hotel"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Guruge Park",
                            Description = "Some desc about Guruge park"
                        }
                    }
                },

                new CityDto()
                {
                    Id = 2,
                    Name = "Kandana",
                    Description = "Some description abt Kandana",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Kandana Church",
                            Description = "Some desc about Kandana Church"
                        }
                    }
                },

                new CityDto()
                {
                    Id = 3,
                    Name = "Waththala",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Waththala church",
                            Description = "Some desc about Waththala church"
                        }
                    }
                }
            };
        }
    }
}