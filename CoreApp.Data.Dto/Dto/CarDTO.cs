using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Dto.Dto
{
    public class CarDTO
    {
        public string LisensePlate { get; set; }

        public string CarColor { get; set; }

        public string CarType { get; set; }

        public string Company { get; set; }

        public long ParkId { get; set; }
        
        public string ParkName { get; set; }
    }
}
