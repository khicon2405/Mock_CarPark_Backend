using System;
using System.Collections.Generic;
using System.Text;
using Common.Dto.Base;

namespace Common.Dto.Base
{
    public class BasePagingSearchResponse<TEntity>: BaseResponse<TEntity> where TEntity: class
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
