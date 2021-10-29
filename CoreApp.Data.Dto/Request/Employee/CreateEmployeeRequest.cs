using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Common.Dto.Base;

namespace CoreApp.Data.Dto.Request.Employee
{
    public class CreateEmployeeRequest : BaseRequest
    {
        public string Account { get; set; }

        [DefaultValue("1")]
        public string Password { get; set; }


        [DefaultValue("employee")]
        public string Department { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        [DefaultValue("1")]
        public string Sex { get; set; }
        public DateTime? DofB { get; set; }

    }
}
