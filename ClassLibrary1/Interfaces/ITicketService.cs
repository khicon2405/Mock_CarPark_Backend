using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Ticket;

namespace CoreApp.Service.Interfaces
{
    public interface ITicketService
    {
        public Task<BaseResponse> Create(CreateNewTicketRequest request);
        /*public Task<BaseResponse> GetAll();*/
       /* public Task<BaseResponse> Update(UpdateTicketRequest request);*/

        public Task<BaseResponse> Delete(long id);

        public Task<TicketDTO> GetById(long id);
        /* public Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request);*/
        /* public IQueryable<EmployeeDTO> FindAll();*/

        public Task<BaseResponse<List<TripDTO>>> GetAll();
    }
}
