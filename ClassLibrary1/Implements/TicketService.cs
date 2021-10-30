using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto.Base;

using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Ticket;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;
using CoreApp.Data.Unit_of_Work;
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
        public async Task<BaseResponse> Create(CreateNewTicketRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var newTicket = _mapper.Map<Ticket>(request);
                await _ticketRepository.Create(newTicket);
                _unitOfWork.Commit();
                response.Success = true;

                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return response;
            }
        }

        public async Task<BaseResponse> Delete(long id)
        {
            var response = new BaseResponse();
            try
            {
                await _ticketRepository.Delete(id);
                _unitOfWork.Commit();
                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                return response;
            }
        }

        public async Task<TicketDTO> GetById(long id)
        {
            try
            {
                var data = await _ticketRepository.GetById(id);
                var response = _mapper.Map<TicketDTO>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse<List<TicketDTO>>> GetAll()
        {
            var response = new BaseResponse<List<TicketDTO>>();
            try
            {
                var all =  _ticketRepository.FindAll();
                _unitOfWork.Commit();
                if (all != null)
                {
                    
                    List<TicketDTO> result = _mapper.Map<List<TicketDTO>>(all);

                    response.Data = result;
                    response.Success = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Errors = "Error";
                    return response;
                }


                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {

                return response;
            }
           
        }


    }
}
