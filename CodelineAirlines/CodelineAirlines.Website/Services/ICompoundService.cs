using CodelineAirlines.Shared.Models.DTOs.AirplaneDTOs;
using CodelineAirlines.Shared.Models.DTOs.AirplaneSpecDTOs;
using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using CodelineAirlines.Shared.Models.DTOs.FlightDTOs;
using CodelineAirlines.Shared.Models.DTOs.ReviewDTOs;
using CodelineAirlines.Shared.Enums;

namespace CodelineAirlines.Website.Services
{
    public interface ICompoundService
    {
        int AddFlight(FlightInputDTO flightInput);

        (int flightNo, int BookingsCount) CancelFlight(int flightId, string condition);

        FlightDetailedOutputDTO GetFlightDetails(int flightNo);

        void AddReview(ReviewInputDTO review);

        public (int FlightNo, DateTime NewDepartureDate) RescheduleFlight(int flightNo, DateTime newDate, int airplaneId = -1);

        (int FlightNo, string? Status) Land(int flightNo);

        List<SeatsOutputDTO> GetAvailableSeats(int flightNo);

        Task<(string airportName, string country, string city)> AddAirport(AirportControllerInputDTO airportInput);

        int ClaculateFlightInputDuration(FlightControllerInput flightControllerInput);

        string AddAirplaneModel(AirplaneSpecInputDTO airplaneSpecInput);
    }
}