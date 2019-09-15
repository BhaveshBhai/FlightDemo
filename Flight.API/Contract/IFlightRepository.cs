using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.API.Models;

namespace Flight.API.Contract
{
    public interface IFlightRepository<T>
    {
        Task FlightInsert(Flights flight);
        Task FlightUpdate(Flights flight);
        Task FlightDelete(string ID);
        IEnumerable<Flights> FlightSelectAll();
        IEnumerable<Flights> FlightSelectOne(string ID);
        IEnumerable<Booking> BookingFilter(Booking booking);
        Task BookingInsert(Booking booking);
        IEnumerable<Flights> FlightAvailability(Flights flights);

    }

}
