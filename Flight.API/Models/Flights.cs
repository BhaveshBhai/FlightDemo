using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flight.API.Models
{
    public partial class Flights
    {
        [Key]
        public int Id { get; set; }
        public string FlightNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? PassCapacity { get; set; }
        public string DepartCity { get; set; }
        public string ArrivalCity { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
