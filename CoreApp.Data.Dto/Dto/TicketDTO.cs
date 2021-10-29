using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Dto.Dto
{
    public class TicketDTO
    {
        public long TicketId { get; set; }

        public TimeSpan? BookingTime { get; set; }

       
        public string CustomerName { get; set; }

        
        public string LicensePlate { get; set; }

        public long TripId { get; set; }
    }
}
