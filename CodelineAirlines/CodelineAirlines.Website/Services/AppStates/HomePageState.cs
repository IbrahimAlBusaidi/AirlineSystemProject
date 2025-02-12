using CodelineAirlines.Shared.Models.DTOs.AirportDTOs;
using CodelineAirlines.Shared.Models.DTOs.FlightDTOs;
using MudBlazor;

namespace CodelineAirlines.Website.Services.AppStates
{
    public class HomePageState
    {
        public event Action OnChange;

        private bool _originEmpty = true;
        public bool originEmpty
        {
            get => _originEmpty;
            set
            {
                _originEmpty = value;
                NotifyStateChanged();
            }
        }

        private bool _destEmpty = true;
        public bool destEmpty
        {
            get => _destEmpty;
            set
            {
                _destEmpty = value;
                NotifyStateChanged();
            }
        }

        public List<AirportOutputDTO> airports { get; set; } = new();
        public List<AirportOutputDTO> airportsOrigin { get; set; } = new();
        public List<AirportOutputDTO> airportsDest { get; set; } = new();
        public List<FlightOutputDTO> flights { get; set; } = new();

        public AirportOutputDTO FromLocation { get; set; }
        public AirportOutputDTO ToLocation { get; set; }
        public DateRange _dateRange = new(DateTime.Now.Date, DateTime.Now.AddDays(30).Date);

        private async void NotifyStateChanged()
        {
            if (OnChange is not null)
            {
                await InvokeAsyncOnMainThread(() => OnChange?.Invoke());
            }
        }

        private async Task InvokeAsyncOnMainThread(Action action)
        {
            await Task.Yield(); // Ensures execution on the UI thread
            action();
        }
    }
}
