using CodelineAirlines.Shared.Models.DTOs.AirplaneDTOs;
using CodelineAirlines.Shared.Models.DTOs.BookingDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.ClientServices
{
    public interface IBookingService
    {
        bool BookFlight(BookingDTO bookingDto);
        bool CancelBooking(int bookingId);
        int CancelFlightBookings(List<int> bookingsIds, string condition);
        IEnumerable<Booking> GetAllBookingsForAdmin();
        List<SeatsOutputDTO> GetAvailableSeats(int flightNo, string seatClass);
        IEnumerable<Booking> GetBookingsForPassenger(string passport);
        void RescheduledFlightBookings(List<int> bookingsIds, DateTime newDate);
        bool UpdateBooking(UpdateBookingDTO bookingDto);
    }
}