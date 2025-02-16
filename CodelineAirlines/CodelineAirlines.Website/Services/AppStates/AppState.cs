using System.ComponentModel;
using CodelineAirlines.Shared.Models;
using CodelineAirlines.Shared.Models.DTOs.AirplaneDTOs;
using CodelineAirlines.Shared.Models.DTOs.PassengerDTOs;
namespace CodelineAirlines.Website.Services.AppStates
{
    public class AppState : INotifyPropertyChanged
    {
        public List<PassengerInputDTOs> PassengersInput { get; set; } = new();
        public List<SeatTemplate> _passengerSelectedSeats { get; set; } = new();
        public List<SeatsOutputDTO> SelectedSeats { get; set; } = new();
        public List<SeatTemplate> PassengerSelectedSeats
        {
            get => _passengerSelectedSeats;
            set
            {
                _passengerSelectedSeats = value;
                NotifyPropertyChanged(nameof(PassengerSelectedSeats));
            }
        }
        public bool notValidSeats { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddSeat(SeatTemplate seat)
        {
            _passengerSelectedSeats.Add(seat);
            if(_passengerSelectedSeats.Count == PassengersInput.Count)
            {
                notValidSeats = false;
            }
            NotifyPropertyChanged(nameof(PassengerSelectedSeats));
            NotifyPropertyChanged(nameof(notValidSeats));
        }

        public void RemoveSeat(SeatTemplate seat)
        {
            _passengerSelectedSeats.RemoveAll(s => s.SeatNumber == seat.SeatNumber);
            if (_passengerSelectedSeats.Count != PassengersInput.Count)
            {
                notValidSeats = true;
            }
            NotifyPropertyChanged(nameof(PassengerSelectedSeats));
            NotifyPropertyChanged(nameof(notValidSeats));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
