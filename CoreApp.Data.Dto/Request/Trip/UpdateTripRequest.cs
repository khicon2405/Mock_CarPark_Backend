using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Dto.Request.Trip
{
    public class UpdateTripRequest :CreateNewTripRequest
    {
        public long TripId { get; set; }
    }
}
