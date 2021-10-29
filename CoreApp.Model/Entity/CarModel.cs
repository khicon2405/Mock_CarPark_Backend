using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreAppData.Entity
{
    public class CarModel

    {
        [Required]
        public int CarModelId { get; set; }
        public string  licensePlate { get; set; }

        public string carColor { get; set; }

        public string carType { get; set; }

        public string company { get; set; }

        public int parkId { get; set; }
       
    }
}
