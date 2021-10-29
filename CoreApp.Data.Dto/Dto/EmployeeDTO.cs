using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Dto.Dto
{
    public class EmployeeDTO
    {

        public long EmployeeId { get; set; }

        public string Account { get; set; }

        public string Department { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }


        public string Sex { get; set; }

        public DateTime? DofB { get; set; }
    }
}
