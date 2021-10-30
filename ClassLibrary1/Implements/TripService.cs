using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto.Base;

using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Trip;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;
using CoreApp.Data.Unit_of_Work;
using CoreApp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CoreApp.Service.Implements
{
    public class TripService : ITripService
    {
        private readonly IGenericRepository<Trip> _tripRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TripService(IGenericRepository<Trip> tripRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Create(CreateNewTripRequest request)
        {
            var response = new BaseResponse();
            try
            {
                
                var newTrip = _mapper.Map<Trip>(request);
                
                await _tripRepository.Create(newTrip);
                _unitOfWork.Commit();
                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }

        }
        public async Task<TripDTO> GetById(long id)
        {
            try
            {
                var data = await _tripRepository.GetById(id);
                var response = _mapper.Map<TripDTO>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }
        public async Task<BaseResponse<List<TripDTO>>> GetAll()
        {
            var response = new BaseResponse<List<TripDTO>>();
            try
            {
                var all =  _tripRepository.FindAll();
                _unitOfWork.Commit();
                if (all != null)
                {
                    
                    List<TripDTO> result = _mapper.Map<List<TripDTO>>(all);

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

        /*public async Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchEmployeeResponse();
            try
            {
                var items = _employeeRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "employeename":
                            case "name":
                                items = items.Where(item => item.Name.Contains(search.FieldValue));
                                break;
                            case "account":
                                items = items.Where(item => item.Account.Contains(search.FieldValue));
                                break;
                            case "address":
                                items = items.Where(item => item.Address.Contains(search.FieldValue));
                                break;
                            case "phonenumber":
                                items = items.Where(item => item.Phone.Contains(search.FieldValue));
                                break;
                            case "department":
                                items = items.Where(item => item.Department.Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                
                List<EmployeeDTO> result = _mapper.Map<List<EmployeeDTO>>(items);
                if (result.Any())
                {
                    response.TotalItems = result.Count;
                    response.TotalPages = (int)Math.Ceiling((decimal)response.TotalItems / request.PageSize);
                    response.Data = result.Skip(request.PageSize * request.PageIndex).Take(request.PageSize).ToList();
                    response.PageSize = request.PageSize;
                    response.PageIndex = request.PageIndex;
                }

                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }*/

        public async Task<BaseResponse> Delete(long id)
        {
            var response = new BaseResponse();
            try
            {
                await _tripRepository.Delete(id);
                _unitOfWork.Commit();
                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }

        public async Task<BaseResponse> Update(UpdateTripRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var tripDb = await _tripRepository.GetById(request.TripId);
                tripDb.bookedTicketNumber = request.bookedTicketNumber;
                tripDb.CarType = request.CarType;
                tripDb.DepartureDate = request.DepartureDate;
                tripDb.Departuretime = request.Departuretime;
                tripDb.Destination = request.Destination;
                tripDb.Driver = request.Driver;
                tripDb.MaximumOnlineTicketNumber = request.MaximumOnlineTicketNumber;
                await _tripRepository.Update(tripDb);
                _unitOfWork.Commit();
                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }

    }
}
