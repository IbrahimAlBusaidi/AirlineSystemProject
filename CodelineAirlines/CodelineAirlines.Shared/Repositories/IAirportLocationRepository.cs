using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface IAirportLocationRepository
    {
        AirportLocation GetAirportLocation(int id);
        void AddLocation(AirportLocation airportLocation);
        void DeleteLocation(AirportLocation airportLocation);
        void UpdateLocation(AirportLocation airportLocation);
    }
}