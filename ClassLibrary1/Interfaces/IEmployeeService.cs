using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Employee;
using CoreApp.Data.Dto.Response.Employee;
using CoreApp.Data.Entity;


namespace CoreApp.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Task<BaseResponse> Create(CreateEmployeeRequest request);
        /*public Task<BaseResponse> GetAll();*/
        public Task<BaseResponse> Update(UpdateEmployeeRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<EmployeeDTO> GetById(long id);
        /* public Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request);*/
        /* public IQueryable<EmployeeDTO> FindAll();*/

        public Task<BaseResponse<List<EmployeeDTO>>> GetAll();
    }
}
