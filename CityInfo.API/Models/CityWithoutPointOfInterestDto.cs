﻿namespace CityInfo.API.Models
{
    /// <summary>
    /// A city without points of interes
    /// </summary>
    public class CityWithoutPointOfInterestDto
    {
        /// <summary>
        /// The id of the city
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the city
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The description of the city
        /// </summary>
        public string? Description { get; set; }
    }
}