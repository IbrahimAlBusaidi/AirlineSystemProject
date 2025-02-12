using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface IBookingRepository
    {
        int AddBooking(Booking booking);
        void CancelBooking(int bookingId);
        int CancelBookingsRange(List<Booking> bookings);
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        IEnumerable<Booking> GetBookingsByPassenger(string passengerPassport);
        void UpdateBooking(Booking booking);
    }
}