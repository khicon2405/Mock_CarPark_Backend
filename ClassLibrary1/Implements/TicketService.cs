using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto.Base;
using Common.UnitOfWork;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Ticket;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;
using CoreApp.Service.Interfaces;

namespace CoreApp.Service.Implements
{
    public class TicketService : ITicketService
    {
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IGenericRepository<Ticket> ticketRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public  async Task<BaseResponse> Create(CreateNewTicketRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var newTicket = _mapper.Map<Ticket>(request);
                await _ticketRepository.Create(newTicket);
                _unitOfWork.Commit();
                response.Success = true;

                return await Task.FromResult(response).ConfigureAwait(false);
            } catch(Exception e) {
                return response;
            }
        }

        public Task<BaseResponse> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<TicketDTO> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<List<TripDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }


    }
}
