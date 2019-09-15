using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.API.Contract;
using Flight.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository<Flights> _FlightRepository;
        private readonly ILogger<FlightController> _logger;
        public FlightController(IFlightRepository<Flights> FlightRepository, ILogger<FlightController> logger)
        {
            _FlightRepository = FlightRepository;
            _logger = logger;
        }
        //[Route("api/Flight/FlightInsert")]
        [HttpPost("FlightInsert")]
        public async Task<IActionResult> FlightInsert(string ArrivalCity, string DepartCity, string EndDate, string FlightNo, string PassCapacity, string StartDate)
        {
            _logger.LogInformation("Flight Insert Method Called");
            try
            {
                var flight = new Flights
                {
                    ArrivalCity = ArrivalCity,
                    DepartCity = DepartCity,
                    StartDate = Convert.ToDateTime(StartDate),
                    EndDate = Convert.ToDateTime(EndDate),
                    FlightNo = FlightNo,
                    PassCapacity = PassCapacity != null ? Convert.ToInt16(PassCapacity) : 0
                };
                await _FlightRepository.FlightInsert(flight);
                _logger.LogInformation("Flight insert Successfully", flight);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Hello()
        {
            var Flight = new Flights();
            try
            {
                await _FlightRepository.FlightInsert(Flight);
            }
            catch (Exception)
            {
                await _FlightRepository.FlightInsert(Flight);
            }
            return Ok();
        }

        [HttpPost("FlightUpdate")]
        public async Task<IActionResult> FlightUpdate(string ID,string ArrivalCity, string DepartCity, string EndDate, string FlightNo, string PassCapacity, string StartDate)
        {
            _logger.LogInformation("FLight Update method called");
            try
            {
                var flight = new Flights
                {
                    Id = Convert.ToInt32(ID),
                    ArrivalCity = ArrivalCity,
                    DepartCity = DepartCity,
                    StartDate = Convert.ToDateTime(StartDate),
                    EndDate = Convert.ToDateTime(EndDate),
                    FlightNo = FlightNo,
                    PassCapacity = PassCapacity != null ? Convert.ToInt16(PassCapacity) : 0
                };

                await _FlightRepository.FlightUpdate(flight);
                _logger.LogInformation("Flight details update sucessfully", flight);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
                                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("FlightDelete/{ID}")]
        public async Task<IActionResult> FlightDelete(string ID)
        {
            try
            {
                await _FlightRepository.FlightDelete(ID);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("FlightSelectAll")]
        public IEnumerable<Flights> FlightSelectAll()
        {
           //List<Flights> flight = _FlightRepository.FlightSelectAll().ToList();
            return _FlightRepository.FlightSelectAll();
        }
        [HttpPost("FlightSelectOne/{ID}")]
        public List<Flights> FlightSelectOne(string ID)
        {
            _logger.LogInformation("Flight Selection method called");
            List<Flights> flight = new List<Flights>();
            try
            {
                flight = _FlightRepository.FlightSelectOne(ID).ToList();
                _logger.LogInformation("Flight detilas send", flight);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
            }
            return flight;
        }
        [HttpPost("BookingFilter")]
        public List<Booking> BookingFilter(string PassName, string BDate, string BArrivalCity, string BDepartCity, string FlightNo, string UserID)
        {
            _logger.LogInformation("Flight booking method called");
            List<Booking> flight = new List<Booking>();
            try
            {
                var booking = new Booking
                {
                    PassengerName = PassName,
                    Bdate = (BDate != null) ? Convert.ToDateTime(BDate) : (DateTime?)null,
                    BarrivalCity = BArrivalCity,
                    BdepartCity = BDepartCity,
                    FlightNo = FlightNo,
                    UserId = (UserID != null) ? Convert.ToInt32(UserID) : (Int32?)null
                };
                flight = _FlightRepository.BookingFilter(booking).ToList();
                _logger.LogInformation("Booking filter return", flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Got exception.");
            }
            return flight;
        }

        [HttpPost("BookingInsert")]
        public async Task<IActionResult> BookingInsert(string BookID, string FlightID, string UserID, string PassengerName, string BDate, string BArrivalCity, string BDepartCity, string Status)
        {
            _logger.LogInformation("Booking Insert Method called");
            try
            {
                var booking = new Booking
                {
                    BookId = BookID,
                    PassengerName = PassengerName,
                    Bdate = Convert.ToDateTime(BDate),
                    BarrivalCity = BArrivalCity,
                    BdepartCity = BDepartCity,
                    Status = Status,
                    FlightId = Convert.ToInt32(FlightID),
                    UserId = Convert.ToInt32(UserID)
                };
                await _FlightRepository.BookingInsert(booking);
                _logger.LogInformation("Booking information inserted", booking);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
                return BadRequest();
            }
            return Ok();

        }
        [HttpPost("FlightAvailability")]
        public List<Flights> FlightAvailability(string StartDate, string EndDate, int NoOfPassenger)
        {
            _logger.LogInformation("Flight Availability details send");
            List<Flights> flightList = new List<Flights>();
            try
            {
                var flight = new Flights
                {
                    StartDate = Convert.ToDateTime(StartDate),
                    EndDate = Convert.ToDateTime(EndDate),
                    PassCapacity = NoOfPassenger
                };
                flightList = _FlightRepository.FlightAvailability(flight).ToList();
                _logger.LogInformation("FlightAvailability list send", flightList);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
            }
            return flightList;
        }
     
    }
}