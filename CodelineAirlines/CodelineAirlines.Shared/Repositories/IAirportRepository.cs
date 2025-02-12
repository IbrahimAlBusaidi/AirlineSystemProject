﻿using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface IAirportRepository
    {
        Airport AddAirport(Airport airport);
        IEnumerable<Airport> GetAllAirports();
        Airport GetAirportByName(string name);
        int UpdateAirport(Airport airport);
        Airport GetAirportById(int id);
        void DeleteAirport(Airport airport);
    }
}