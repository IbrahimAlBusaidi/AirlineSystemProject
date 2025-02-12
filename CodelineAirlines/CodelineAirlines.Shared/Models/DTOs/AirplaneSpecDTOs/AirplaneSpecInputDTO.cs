using CodelineAirlines.Shared.Models;
using CodelineAirlines.Shared.Models.DTOs.AirplaneDTOs;
using System.ComponentModel.DataAnnotations;

namespace CodelineAirlines.Shared.Models.DTOs.AirplaneSpecDTOs
{
    public class AirplaneSpecInputDTO
    {
        [Required]
        public string Model { get; set; }

        public double AvgSpeed { get; set; } = 850;

        [Required]
        public double LuggageCapacity { get; set; }

        public GenerateSeatTemplateDto SeatTemplate { get; set; }
    }
}
