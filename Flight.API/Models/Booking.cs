using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.API.Models
{
    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        public string BookId { get; set; }
        public string PassengerName { get; set; }
        public  DateTime? Bdate { get; set; }
        public string BarrivalCity { get; set; }
        public string BdepartCity { get; set; }
        public string Status { get; set; }
        [ForeignKey("FlightId")]
        public virtual Flights Flight { get; set; }
        public int FlightId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
        public int? UserId { get; set; }
        [NotMapped]
        public string FlightNo { get; set; }
    }
}
