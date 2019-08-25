using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using FlightManagement.Api.Helpers;
using FlightManagement.Api.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Data;
namespace FlightManagement.Api.Controllers
{
    public class FlightController : ApiController
    {
        public User Login(string username, string password)
        {
            var result = FlightHelper.CheckLogin(username, password);
            return result;
        }

        [Route("api/Flight/FlightInsert")]
        public bool FlightInsert(string ArrivalCity, string DepartCity, string EndDate, string FlightNo, string PassCapacity, string StartDate)
        {
            try
            {
                var flight = new Flights();
                flight.ArrivalCity = ArrivalCity;
                flight.DepartCity = DepartCity;
                flight.EndDate = EndDate;
                flight.FlightNo = FlightNo;
                flight.PassCapacity = PassCapacity != null ? Convert.ToInt16(PassCapacity) : 0;
                flight.StartDate = StartDate;
                var result = FlightHelper.FlightInsert(flight);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Route("api/Flight/FlightUpdate")]
        public bool FlightUpdate(string ID, string ArrivalCity, string DepartCity, string EndDate, string FlightNo, string PassCapacity, string StartDate)
        {
            try
            {
                var flight = new Flights();
                flight.ID = Convert.ToInt64(ID);
                flight.ArrivalCity = ArrivalCity;
                flight.DepartCity = DepartCity;
                flight.EndDate = EndDate;
                flight.FlightNo = FlightNo;
                flight.PassCapacity = PassCapacity != null ? Convert.ToInt16(PassCapacity) : 0;
                flight.StartDate = StartDate;
                var result = FlightHelper.FlightUpdate(flight);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("api/Flight/FlightDelete/{ID}")]
        public bool FlightDelete(string ID)
        {
            try
            {
                var result = FlightHelper.FlightDelete(ID);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/flight/FlightSelectAll")]
        public List<Flights> FlightSelectAll()
        {
            try
            {
                var result = FlightHelper.FlightSelectAll();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/Flight/FlightSelectOne/{ID}")]
        public Flights FlightSelectOne(string ID)
        {
            try
            {
                var result = FlightHelper.FlightSelectOne(ID);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/Flight/FlightAvailability")]
        public List<Flights> FlightAvailability(string StartDate, string EndDate, int NoOfPassenger)
        {
            try
            {
                var result = FlightHelper.FlightsAvailability(StartDate, EndDate, NoOfPassenger);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/Flight/BookingFilter")]
        public List<Passenger> BookingFilter(string PassName, string BDate, string BArrivalCity, string BDepartCity, string FlightNo, string UserID)
        {
            try
            {
                var uid = Convert.ToInt32(UserID);
                var result = FlightHelper.BookingFilter(PassName, BDate, BArrivalCity, BDepartCity, FlightNo, uid);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("api/Flight/BookingInsert")]
        public bool BookingInsert(string BookID, string FlightID, string UserID, string PassengerName, string BDate, string BArrivalCity, string BDepartCity, string Status)
        {
            try
            {
                var passenger = new Passenger();
                passenger.BookID = BookID;
                passenger.FlightID = Convert.ToInt64(FlightID);
                passenger.UserID = UserID;
                passenger.PessName = PassengerName;
                passenger.BDate = BDate;
                passenger.BArrivalCity = BArrivalCity;
                passenger.BDepartCity = BDepartCity;
                passenger.Status = Status;
                var result = FlightHelper.BookingInsert(passenger);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Route("api/Flight/BookingAll")]
        public List<Passenger> BookingAll(string userId)
        {
            try
            {
                var result = FlightHelper.BookingSelectAll(userId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/Flight/BookingWaitingAll")]
        public List<Passenger> BookingWaitingAll()
        {
            try
            {
                var result = FlightHelper.BookingWaitingAll();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
