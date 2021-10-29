using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreAppData.Entity
{
    public class Ticket
    {
        [Required]
        public int TicketId { get; set; }
        public int ticketId { get; set; }

        public DateTime bookTime { get; set; }

        public string customerName { get; set; }

        public string licensePlate { get; set; }

        public int tripId { get; set; }

    }
}
