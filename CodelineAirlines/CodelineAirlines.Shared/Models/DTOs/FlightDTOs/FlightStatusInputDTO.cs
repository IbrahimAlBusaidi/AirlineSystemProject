using CodelineAirlines.Shared.Enums;

namespace CodelineAirlines.Shared.Models.DTOs.FlightDTOs
{
    public class FlightStatusInputDTO
    {
        public int FlightNo { get; set; }
        public FlightStatus FlightStatus { get; set; }
    }
}
