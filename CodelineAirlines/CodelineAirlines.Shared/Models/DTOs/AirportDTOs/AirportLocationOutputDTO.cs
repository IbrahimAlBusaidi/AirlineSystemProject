using System.ComponentModel.DataAnnotations;

namespace CodelineAirlines.Shared.Models.DTOs.AirportDTOs
{
    public class AirportLocationOutputDTO
    {
        public double AirportLatitude { get; set; }

        public double AirportLongitude { get; set; }
    }
}
