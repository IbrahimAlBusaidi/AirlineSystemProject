using AutoMapper;
using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using CodelineAirlines.Shared.Models;
using CodelineAirlines.Shared.Repositories;

namespace CodelineAirlines.Website.Services.AdminServices
{
    public class AirportLocationService : IAirportLocationService
    {
        private readonly IAirportLocationRepository _airportLocationRepository;
        private readonly IMapper _mapper;

        public AirportLocationService(IAirportLocationRepository airportLocationRepository, IMapper mapper)
        {
            _airportLocationRepository = airportLocationRepository;
            _mapper = mapper;
        }

        public AirportLocationOutputDTO GetAirportLocation(int airportId)
        {
            var location = _airportLocationRepository.GetAirportLocation(airportId);
            return _mapper.Map<AirportLocationOutputDTO>(location);
        }

        public void AddAirportLocation(AirportLocation airportLocation)
        {
            _airportLocationRepository.AddLocation(airportLocation);
        }

        public void UpdateAirportLocation(AirportLocation airportLocation)
        {
            _airportLocationRepository.UpdateLocation(airportLocation);
        }

        public void DeleteAirportLocation(AirportLocation airportLocation)
        {
            _airportLocationRepository.DeleteLocation(airportLocation);
        }
    }
}
