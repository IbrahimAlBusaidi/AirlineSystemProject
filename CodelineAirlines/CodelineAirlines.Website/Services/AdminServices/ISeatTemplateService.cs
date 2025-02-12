using CodelineAirlines.Shared.Models.DTOs.AirplaneDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.AdminServices
{
    public interface ISeatTemplateService
    {
        void GenerateSeatTemplatesForModel(GenerateSeatTemplateDto dto);

        // Retrieves seat templates by airplane model name, ordered by SeatCost in descending order
        IEnumerable<SeatTemplate> GetSeatTemplatesByModel(string airplaneModel);

        // Deletes all SeatTemplates by Airplane Model
        void DeleteSeatTemplatesByModel(string airplaneModel);
        List<string> GetAllAvailableModels();
    }
}