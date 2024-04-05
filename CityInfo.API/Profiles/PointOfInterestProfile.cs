﻿using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
            CreateMap<PointOfInterestCreationDto, PointOfInterest>();
            CreateMap<PointOfInterestUpdateDto, PointOfInterest>();
            CreateMap<PointOfInterest, PointOfInterestUpdateDto>();
        }
    }
}