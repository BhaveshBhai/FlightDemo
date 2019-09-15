using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.API.Models
{
    public class Passenger
    {
        public Int64 ID { get; set; }
        public string BookID { get; set; }
        public Int64 FlightID { get; set; }
        public string BDate { get; set; }
        public string PessName { get; set; }
        public string BArrivalCity { get; set; }
        public string BDepartCity { get; set; }
        public string UserID { get; set; }
        public string FlightNo { get; set; }
        public string Status { get; set; }
    }
}
