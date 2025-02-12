using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface IAirplaneSpecRepository
    {
        AirplaneSpecs AddAirplaneSpecs(AirplaneSpecs airplaneSpecs);
        IQueryable<AirplaneSpecs> GetAirplaneModelsSpecs();
        AirplaneSpecs GetAirplaneSpecsByModel(string model);
        string UpdateAirplaneSpec(AirplaneSpecs airplaneSpecs);
    }
}