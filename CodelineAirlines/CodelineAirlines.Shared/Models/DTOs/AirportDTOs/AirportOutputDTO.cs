﻿using System.ComponentModel.DataAnnotations;

namespace CodelineAirlines.Shared.Models.DTOs.AirportDTOs
{
    public class AirportOutputDTO
    {
        public int AirportId { get; set; }
        public string AirportName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
