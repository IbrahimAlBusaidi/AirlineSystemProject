using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace CodelineAirlines.Shared.Enums
{
    public enum FlightStatus
    {

        Scheduled = 0,
        OnTime = 1,
        Delayed = 2,
        InFlight = 3,
        Arrived = 4,
        Canceled = 5,
        ReScheduled = 6
    }
}
