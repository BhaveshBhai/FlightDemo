using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManagement.Api.Models
{
    public enum CRUDEnum
    {
        Insert=0,
        Update=1,
        Delete=2,
        SelectOne=3,
        SelectAll=4
    }
}