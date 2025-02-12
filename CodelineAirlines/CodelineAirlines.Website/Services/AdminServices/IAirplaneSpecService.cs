using CodelineAirlines.Shared.Models.DTOs.AirplaneSpecDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.AdminServices
{
    public interface IAirplaneSpecService
    {
        AirplaneSpecs AddAirplaneSpecs(AirplaneSpecInputDTO airplaneSpecInputDTO);
        List<AirplaneSpecOutputDTO> GetModelsSpecs();
        List<AirplaneSpecs> GetModelsSpecsWithRelatedData();
        AirplaneSpecOutputDTO GetSpecsByModel(string modelName);
        AirplaneSpecs GetSpecsByModelWithRelatedData(string modelName);
    }
}