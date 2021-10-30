using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreApp.Data.Entity
{
    public class TripModel
    {
        [Required]
        public int TripModelId { get; set; }
        public int tripId { get; set; }
        public int bookedTicketNumber { get; set; }
        public string carType { get; set; }

        public DateTime departureDate { get; set; }
        public DateTime departureTime { get; set; }
        public string destination { get; set; }
        public string driver { get; set; }
        public int maximumOnlineTicketNumber { get; set; }
    }
}
