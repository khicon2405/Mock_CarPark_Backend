using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Dto.Dto
{
    public class TripDTO { 
        public long TripId { get; set; }

        public int bookedTicketNumber { get; set; }

        
        public string CarType { get; set; }

        
        public DateTime? DepartureDate { get; set; }

        public TimeSpan? Departuretime { get; set; }

        
        public string Destination { get; set; }

      
        public string Driver { get; set; }

        public int MaximumOnlineTicketNumber { get; set; }
    
    }
}
