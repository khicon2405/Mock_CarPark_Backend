using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Trip;

namespace CoreApp.Service.Interfaces
{
    public interface ITripService
    {
        public Task<BaseResponse> Create(CreateNewTripRequest request);
        /*public Task<BaseResponse> GetAll();*/
        public Task<BaseResponse> Update(UpdateTripRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<TripDTO> GetById(long id);
        /* public Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request);*/
        /* public IQueryable<EmployeeDTO> FindAll();*/

        public Task<BaseResponse<List<TripDTO>>> GetAll();
    }
}
