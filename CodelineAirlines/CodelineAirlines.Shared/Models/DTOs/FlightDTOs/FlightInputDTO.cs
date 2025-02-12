﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodelineAirlines.Shared.Models.DTOs.FlightDTOs
{
    public class FlightInputDTO
    {
        [Required(ErrorMessage = "Source airport name is required")]
        public string SourceAirportName { get; set; }

        [Required(ErrorMessage = "Destination airport name is required")]
        public string DestinationAirportName { get; set; }

        [Required(ErrorMessage = "Airplane ID is required")]
        public int AirplaneId { get; set; }

        [Required]
        [Range(0.01, int.MaxValue, ErrorMessage = "Flight cost must be greater than 0")]
        public decimal Cost { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime ScheduledDepartureDate { get; set; }
    }
}
