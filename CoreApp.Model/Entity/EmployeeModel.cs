using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreAppData.Entity
{
    public class EmployeeModel
    {
        [Required]
        public int EmployeeModelId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string userName { get; set; }


        [Required]
        [Column(TypeName = "varchar(20)")]
        public string passWord { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        public string department { get; set; }



        [Required]
        
        public DateTime DateOfBirth { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        public string phone { get; set; }

        [Required]
        [Column(TypeName = "varchar(1)")]
        public string sex { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string address { get; set; }




    }
}
