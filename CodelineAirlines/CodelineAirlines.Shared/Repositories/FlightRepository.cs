using CodelineAirlines.Shared;
using CodelineAirlines.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CodelineAirlines.Shared.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddFlight(Flight flight)
        {
            flight.ScheduledDepartureDate = flight.ScheduledDepartureDate.ToUniversalTime();
            flight.ActualDepartureDate = flight.ActualDepartureDate.Value.ToUniversalTime();
            _context.Flights.Add(flight);
            _context.SaveChanges();

            return flight.FlightNo;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.SourceAirport)
                .Include(f => f.DestinationAirport);
        }

        public int UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();

            return flight.FlightNo;
        }

        public int CancelFlight(Flight flight)
        {
            _context.Flights.Update(flight);

            return flight.FlightNo;
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.SourceAirport)
                .Include(f => f.DestinationAirport)
                .Include(f => f.Bookings)
                .FirstOrDefault(f => f.FlightNo == id);
        }
    }
}
