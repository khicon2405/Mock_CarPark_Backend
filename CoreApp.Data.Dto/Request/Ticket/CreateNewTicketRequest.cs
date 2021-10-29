using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Dto.Request.Ticket
{
    public class CreateNewTicketRequest

    {
        public TimeSpan? BookingTime { get; set; }

        public string CustomerName { get; set; }

        public string LicensePlate { get; set; }

        public long TripId { get; set; }
    }
}
