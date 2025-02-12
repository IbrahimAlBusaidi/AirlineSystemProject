using CodelineAirlines.Shared.Models.DTOs.FlightDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.AdminServices
{
    public interface IFlightService
    {
        int AddFlight(Flight flightInput);
        List<Flight> GetAllFlightsWithRelatedData();

        List<FlightOutputDTO> GetAllFlights();
        List<Flight> GetFlightsByDateInterval(DateTime startDate, DateTime endDate);
        Flight GetFlightByIdWithRelatedData(int id);
        int CancelFlight(Flight flight);
        IEnumerable<Flight> GetAirplaneFlightSchedule(int airplaneId, int flightNo = -1);
        (int FlightNo, string? Status) StartFlight(int flightNo);
        (int FlightNo, string? Status) StartAirplaneBoarding(int flightNo);
    }
}