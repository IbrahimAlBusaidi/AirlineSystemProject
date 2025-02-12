using AutoMapper;
using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using CodelineAirlines.Shared.Models.DTOs.FlightDTOs;
using CodelineAirlines.Shared.Models;
using CodelineAirlines.Website.Services.AdminServices;

namespace CodelineAirlines.Website.Services.Mapping
{
    public class SourceAirportNameResolver : IValueResolver<FlightInputDTO, Flight, int>
    {
        private readonly IAirportService _airportService;

        public SourceAirportNameResolver(IAirportService airportService)
        {
            _airportService = airportService;
        }

        public int Resolve(FlightInputDTO source, Flight destination, int member, ResolutionContext context)
        {
            var airport = _airportService.GetAirportByNameWithRelatedData(source.SourceAirportName);
            return airport?.AirportId ?? -1;
        }
    }

    public class DestinationAirportNameResolver : IValueResolver<FlightInputDTO, Flight, int>
    {
        private readonly IAirportService _airportService;

        public DestinationAirportNameResolver(IAirportService airportService)
        {
            _airportService = airportService;
        }

        public int Resolve(FlightInputDTO source, Flight destination, int member, ResolutionContext context)
        {
            var airport = _airportService.GetAirportByNameWithRelatedData(source.DestinationAirportName);
            return airport?.AirportId ?? -1;
        }
    }
}
