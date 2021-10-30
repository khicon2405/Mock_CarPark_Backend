using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreApp.Data.Entity
{
    public class BookingOfficeModel
    {
        [Required]
        public int BookingOfficeModelId { get; set; }
        public int officeId { get; set; }
        public int parkArea { get; set; }
        public string parkName {get;set;}
        public string parkPlace { get; set; }

        public int parkPrice { get; set; }
        public string parkStutus { get; set; }
    }
}
