using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface ISeatTemplateRepository
    {
        IEnumerable<SeatTemplate> GetAllModels();
        void Add(SeatTemplate seatTemplate);

        // Retrieves seat templates by airplane model name, ordered by SeatCost in descending order
        IEnumerable<SeatTemplate> GetSeatTemplatesByModel(string airplaneModel);

        // Deletes all SeatTemplates by Airplane Model
        void DeleteByModel(string airplaneModel);
    }
}