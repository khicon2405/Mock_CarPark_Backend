using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Car;
using CoreApp.Data.Dto.Response.Car;

namespace CoreApp.Service.Interfaces
{
    public interface ICarService
    {
        public Task<BaseResponse> Create(CreateCarRequest request);
         public Task<BaseResponse<List<CarDTO>>> GetAll();

        public Task<BaseResponse> Update(UpdateCarRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<CarDTO> GetById(long id);

/*        public Task<PagingSearchCarResponse> GetByPagingAndFilter(BasePagingSearchRequest request);
*/    }
}
