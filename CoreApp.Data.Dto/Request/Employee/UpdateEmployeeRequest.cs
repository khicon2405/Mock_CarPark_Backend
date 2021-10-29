using System;
using System.Collections.Generic;
using System.Text;
using Common.Dto.Base;

namespace CoreApp.Data.Dto.Request.Employee
{
    public class UpdateEmployeeRequest : CreateEmployeeRequest
    {
        public long Id { get; set; }
    }
}
