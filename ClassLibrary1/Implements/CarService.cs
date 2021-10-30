using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto.Base;

using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Car;
using CoreApp.Data.Dto.Response.Car;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;
using CoreApp.Data.Unit_of_Work;
using CoreApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Service.Implements
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IGenericRepository<Car> repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._carRepository = repo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateCarRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var item = _mapper.Map<Car>(request);
                await _carRepository.Create(item);
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
        public async Task<BaseResponse<List<CarDTO>>> GetAll()
        {
            var response = new BaseResponse<List<CarDTO>>();
            try
            {
                var all =  _carRepository.FindAll();
                _unitOfWork.Commit();
                if (all != null)
                {
                    
                    List<CarDTO> result = _mapper.Map<List<CarDTO>>(all);

                    response.Data = result.ToList();
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
        public async Task<BaseResponse> Delete(long id)
        {
            var response = new BaseResponse();
            try
            {
                await _carRepository.Delete(id);
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

       /* public async Task<PagingSearchCarResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchCarResponse();
            try
            {
                var items = _carRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "licenseplate":
                                items = items.Where(item => item.LisensePlate.Contains(search.FieldValue));
                                break;
                            case "cartype":
                                items = items.Where(item => item.CarType.Contains(search.FieldValue));
                                break;
                            case "carcolor":
                                items = items.Where(item => item.CarColor.Contains(search.FieldValue));
                                break;
                            case "company":
                                items = items.Where(item => item.Company.Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                items = items.Include(item => item.ParkingLot);
                List<CarDTO> result = _mapper.Map<List<CarDTO>>(items);
                if (result.Any())
                {
                    response.TotalItems = result.Count;
                    response.TotalPages = (int)Math.Ceiling((decimal)response.TotalItems / request.PageSize);
                    response.Data = result.Skip(request.PageSize * request.PageIndex).Take(request.PageSize).ToList();

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

        public async Task<CarDTO> GetById(long id)
        {
            try
            {
                var data = _carRepository.GetDbSet().
                    Include(item => item.ParkingLot).
                    FirstOrDefault(item => item.LisensePlate == id.ToString());
                var response = _mapper.Map<CarDTO>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateCarRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var carDb = await _carRepository.GetById(request.LisensePlate);
                carDb.ParkId = request.ParkId;
                carDb.CarColor = request.CarColor;
                carDb.CarType= request.CarType;
                carDb.Company= request.Company;
   
                await _carRepository.Update(carDb);
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
