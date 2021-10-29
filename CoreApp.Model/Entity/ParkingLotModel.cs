using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreAppData.Entity
{
    public class ParkingLotModel
    {
        [Required]

        public int ParkingLotModelId { get; set; }
        public int parkId { get; set; }

        public int parkArea {get;set; }

        public string parkName { get; set; }

        public string parkPlace { get; set; }

        public int parkPrice { get; set; }

        public string parkStatus { get; set; }
    }
}
