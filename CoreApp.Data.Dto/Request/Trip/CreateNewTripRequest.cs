using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoreApp.Data.Dto.Request.Trip
{
    public class CreateNewTripRequest
    {
        [DefaultValue(1)]
        public int bookedTicketNumber { get; set; }
        public string CarType { get; set; }
         public DateTime? DepartureDate { get; set; }

        public TimeSpan? Departuretime { get; set; }
        public string Destination { get; set; }

        public string Driver { get; set; }

        [DefaultValue(20)]
        public int MaximumOnlineTicketNumber { get; set; }
    }
}
