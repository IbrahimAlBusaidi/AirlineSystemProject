using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.AdminServices
{
    public interface IAirportLocationService
    {
        AirportLocationOutputDTO GetAirportLocation(int airportId);
        void AddAirportLocation(AirportLocation airportLocation);
        void DeleteAirportLocation(AirportLocation airportLocation);
        void UpdateAirportLocation(AirportLocation airportLocation);
    }
}