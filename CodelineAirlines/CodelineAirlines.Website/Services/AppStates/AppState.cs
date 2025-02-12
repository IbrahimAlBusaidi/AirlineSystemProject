using CodelineAirlines.Shared.Models.DTOs.AirplaneDTOs;
using CodelineAirlines.Shared.Models.DTOs.PassengerDTOs;
namespace CodelineAirlines.Website.Services.AppStates
{
    public class AppState
    {
        public List<PassengerInputDTOs> PassengersInput { get; set; } = new();

        public List<SeatsOutputDTO> SelectedSeats { get; set; } = new();


        public event Action? OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
