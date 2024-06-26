﻿using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInterestUpdateDto
    {
        [Required(ErrorMessage = "You should provide a valid name.")]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}