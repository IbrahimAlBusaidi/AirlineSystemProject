using System.ComponentModel;
using CodelineAirlines.Shared.Models.DTOs.PassengerDTOs;

namespace CodelineAirlines.Website.Services.AppStates
{
    public class BookingState : INotifyPropertyChanged
    {
        public List<PassengerOutputDTO> passengers { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;

        private List<PassengerInputDTOs> _passengerList = new();
        public List<PassengerInputDTOs> PassengerList
        {
            get => _passengerList;
            set
            {
                _passengerList = value;
                NotifyPropertyChanged(nameof(PassengerList));
            }
        }
        public bool isPassengerListEmpty { get; set; } = true;

        public void AddPassenger(PassengerInputDTOs passenger)
        {
            _passengerList.Add(passenger);
            isPassengerListEmpty = _passengerList.Count == 0;
            NotifyPropertyChanged(nameof(PassengerList));
            NotifyPropertyChanged(nameof(isPassengerListEmpty));
        }

        public void RemovePassenger(PassengerInputDTOs passenger)
        {
            _passengerList.Remove(passenger);
            isPassengerListEmpty = _passengerList.Count == 0;
            NotifyPropertyChanged(nameof(PassengerList));
            NotifyPropertyChanged(nameof(isPassengerListEmpty));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
