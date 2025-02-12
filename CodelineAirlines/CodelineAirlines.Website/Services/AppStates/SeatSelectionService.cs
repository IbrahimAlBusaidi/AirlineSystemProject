using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.AppStates
{
    public class SeatSelectionService
    {
        public List<SeatTemplate> SelectedSeats { get; private set; } = new();

        public void SetSelectedSeats(List<SeatTemplate> seats)
        {
            SelectedSeats = seats;
        }
    }
}
