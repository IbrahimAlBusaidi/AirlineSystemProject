using CodelineAirlines.Shared.Models.DTOs.PassengerDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.ClientServices
{
    public interface IPassengerService
    {
        void AddPassenger(PassengerInputDTOs passengerInputDTO, int userId, bool isAdmin);
        List<PassengerOutputDTO> GetPassengerProfile(int userId);
        void UpdatePassengerDetails(int userId, PassengerInputDTOs passengerInputDTO);
        int GetLoyaltyPoints(int userId);
        Passenger? GetPassengerByPassport(string passport);

    }
}