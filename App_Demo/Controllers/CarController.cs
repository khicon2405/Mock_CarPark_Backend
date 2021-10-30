using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Car;
using CoreApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("create-new-car")]
        public async Task<BaseResponse> Create([FromBody] CreateCarRequest request)
        {
            return await _carService.Create(request).ConfigureAwait(false);
        }

        [HttpGet("get-all-car")]
        public async Task<BaseResponse<List<CarDTO>>> GetAll()
        {
            return await _carService.GetAll().ConfigureAwait(false);
        }
        [HttpGet("get-car-by-id")]
        public async Task<CarDTO> GetCarById([FromBody] long id)
        {
            return await _carService.GetById(id).ConfigureAwait(false);
        }

        [HttpPut("update-car")]
        public async Task<BaseResponse> Update([FromBody] UpdateCarRequest request)
        {
            return await _carService.Update(request).ConfigureAwait(false);
        }
        [HttpDelete("delete-car")]
        public async Task<BaseResponse> Delete([FromBody] long id)
        {
            return await _carService.Delete(id).ConfigureAwait(false);
        }
    }


}
