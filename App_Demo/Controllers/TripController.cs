using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Trip;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;
using CoreApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost("create-new-trip")]
        public async Task<BaseResponse> CreateTrip([FromBody] CreateNewTripRequest request)
        {
            return await _tripService.Create(request).ConfigureAwait(false);
        }

        [HttpGet("get-all-trip")]
        public async Task<BaseResponse<List<TripDTO>>> GetAllTrip()
        {
            return await _tripService.GetAll().ConfigureAwait(false);
        }

        [HttpPut("update-trip")]
        public async Task<BaseResponse> UpdateTrip(UpdateTripRequest request)
        {
            return await _tripService.Update(request).ConfigureAwait(false);
        }

        [HttpGet("get-trip-by-id")]
        public async Task<TripDTO> GetTripById(long Id)
        {
            return await _tripService.GetById(Id).ConfigureAwait(false);
        }

        [HttpDelete("delete-trip")]
        public async Task<BaseResponse> DeleteTrip(long id)
        {
            return await _tripService.Delete(id).ConfigureAwait(false);
        }
    }
}
