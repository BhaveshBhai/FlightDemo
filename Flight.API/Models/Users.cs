using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.API.Models
{
    public partial class Users
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("RoleId")]
        public virtual Roles Role { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
