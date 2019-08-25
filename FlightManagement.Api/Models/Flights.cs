using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManagement.Api.Models
{
    public class Flights
    {
        public Int64 ID { get; set; }
        public string FlightNo{get;set;}
        public string StartDate {get;set;}
        public string EndDate {get;set;}
        public int PassCapacity{get;set;}
        public int NoPass { get; set; }
        public string DepartCity{get;set;}
        public string ArrivalCity{get;set;}
        public int UserID { get; set; }
        public string BDate { get; set; }
        public string PassName { get; set; }
        public string Status { get; set; }
    }
}