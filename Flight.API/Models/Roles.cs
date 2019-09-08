using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flight.API.Models
{
    public partial class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
