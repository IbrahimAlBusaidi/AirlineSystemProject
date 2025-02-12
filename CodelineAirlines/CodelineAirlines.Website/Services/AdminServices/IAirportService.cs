using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.AdminServices
{
    public interface IAirportService
    {
        Airport AddAirport(AirportInputDTO airportInputDTO);
        List<AirportOutputDTO> GetAllAirports();
        AirportOutputDTO GetAirportByName(string name);
        int UpdateAirport(AirportInputDTO airportInput, int id);
        void DeleteAirport(int id);
        int DeactivateAirport(int id);
        int ReactivateAirport(int id);
        Airport GetAirportByNameWithRelatedData(string name);
    }
}