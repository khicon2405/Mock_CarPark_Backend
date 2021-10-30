using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreApp.Data.Entity
{
    public class AuthenticationModel
    {
        [Required]
        public int AuthenticationModelId { get; set; }
       
    }
}
