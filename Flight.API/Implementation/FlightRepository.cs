using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Flight.API.Contract;
using Flight.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight.API.Implementation
{
    public class FlightRepository : IFlightRepository<Flights>
    {
        readonly FlightManagmentContext _Context;
        public FlightRepository(FlightManagmentContext context)
        {
            _Context = context;
        }


        public async Task FlightInsert(Flights flights)
        {
            try
            {
                await _Context.Flights.AddAsync(flights);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task FlightUpdate(Flights flights)
        {
            try
            {
                _Context.Entry(flights).State = EntityState.Modified;
                _Context.Flights.Update(flights);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task FlightDelete(string ID)
        {
            try
            {
                var Flight = await _Context.Flights.FindAsync(Convert.ToInt32(ID));
                _Context.Flights.Remove(Flight);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<Flights> FlightSelectAll()
        {
            return _Context.Flights.ToList();
        }
        public IEnumerable<Flights> FlightSelectOne(string ID)
        {
            return _Context.Flights.Where(x => x.Id == Convert.ToInt32(ID)).ToList();
        }

        public async Task BookingInsert(Booking booking)
        {
            try
            {
                await _Context.Booking.AddAsync(booking);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<Booking> BookingFilter(Booking booking)
        {
            try
            {
                if (booking.PassengerName == null && booking.Bdate == null && booking.BarrivalCity == null &&
                    booking.BdepartCity == null && booking.FlightNo == null && booking.UserId != null)
                    return _Context.Booking.Include(x => x.Flight).Where(x => x.UserId == booking.UserId).ToList();
                else
                    return _Context.Booking.Include(x => x.Flight).Where(x =>
                        x.PassengerName.Contains(booking.PassengerName) ||
                        x.Bdate == booking.Bdate || x.BarrivalCity == booking.BarrivalCity ||
                        x.BdepartCity == booking.BdepartCity
                        || x.Flight.FlightNo == booking.FlightNo && x.UserId == booking.UserId).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IEnumerable<Flights> FlightAvailability(Flights flights)
        {
            try
            {
                var data = _Context.Flights.Where((x=>x.StartDate >= flights.StartDate && x.StartDate <= flights.EndDate &&
                                                      x.EndDate >= flights.StartDate && x.EndDate <= flights.EndDate)).Select(x => new Flights()
                {
                    Id = x.Id,
                    FlightNo = x.FlightNo,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    PassCapacity = x.PassCapacity,
                    DepartCity = x.DepartCity,
                    ArrivalCity = x.ArrivalCity,
                    Status = (x.PassCapacity-(_Context.Booking.Where(y => y.FlightId == x.Id).Count()))>=flights.PassCapacity? "Available": "WaitList"
                }).ToList();
                return data;
            }
            catch (Exception e)
            {
                throw;
            }

        }


    }
}
