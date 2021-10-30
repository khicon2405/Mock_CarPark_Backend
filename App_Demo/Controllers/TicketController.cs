using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dto.Base;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Ticket;
using CoreApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Demo.Controllers
{
   /* [Authorize]*/
   [ApiController]
   [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("create-new-ticket")]
         public async Task<BaseResponse> Create([FromBody] CreateNewTicketRequest request)
        {
            return await _ticketService.Create(request).ConfigureAwait(false);
        }

        [HttpGet("get-all-ticket")]
        public async Task<BaseResponse<List<TicketDTO>>> GetAllTicket()
        {
            return await _ticketService.GetAll().ConfigureAwait(false);
        }

        [HttpDelete("delete-ticket")]
        public async Task<BaseResponse> DeteleTicket(long id)
        {
            return await _ticketService.Delete(id).ConfigureAwait(false);
        }
    }
}
