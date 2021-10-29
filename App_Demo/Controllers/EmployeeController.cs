using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Data.Entity;
using CoreApp.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using CoreApp.Data.Repository;
using CoreApp.Service.Interfaces;
using Common.Dto.Base;
using CoreApp.Data.Dto.Request.Employee;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Response.Employee;
using Microsoft.AspNetCore.Authorization;

namespace App_Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase

    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpPost("create-new-employee")]
        public async Task<BaseResponse> Create([FromBody] CreateEmployeeRequest request)
        {
            return await _employeeService.Create(request);
        }


        [HttpGet("get-employee-by-id")]
        public async Task<EmployeeDTO> GetById(long id)
        {
            return await _employeeService.GetById(id);
        }


        [HttpDelete("delete-employee")]
        public async Task<BaseResponse> Delete(long id)
        {
            return await _employeeService.Delete(id);
        }

        [HttpGet("get-all-employee")]
        public async Task<BaseResponse<List<EmployeeDTO>>> GetAll()
        {
            return await _employeeService.GetAll();
        }


        /*[HttpPost("get-employee-by-filter")]
        public async Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _employeeService.GetByPagingAndFilter(request);
        }*/


        [HttpPut("update-employee")]
        public async Task<BaseResponse> Update(UpdateEmployeeRequest request)
        {
            return await _employeeService.Update(request);
        }

    }
}
