using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto.Base;
using Common.UnitOfWork;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Employee;
using CoreApp.Data.Dto.Response.Employee;
using CoreApp.Data.Entity;
using CoreApp.Data.Repository;

using CoreApp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CoreApp.Service.Implements
{
    public class EmployeeService : BaseService, IEmployeeService

    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Create(CreateEmployeeRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var hasher = new PasswordHasher<Employee>();
                var newEm = _mapper.Map<Employee>(request);
                newEm.Password = hasher.HashPassword(null, request.Password);
                await _employeeRepository.Create(newEm);
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
        public async Task<EmployeeDTO> GetById(long id)
        {
            try
            {
                var data = await _employeeRepository.GetById(id);
                var response = _mapper.Map<EmployeeDTO>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }
        public async Task<BaseResponse<List<EmployeeDTO>>> GetAll()
        {
            var response = new BaseResponse<List<EmployeeDTO>>();
            try
            {
                var all =  _employeeRepository.FindAll();
                _unitOfWork.Commit();
                if (all != null)
                {
                    
                    List<EmployeeDTO> result = _mapper.Map<List<EmployeeDTO>>(all);

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
                await _employeeRepository.Delete(id);
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

        public async Task<BaseResponse> Update(UpdateEmployeeRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var employeeDb = await _employeeRepository.GetById(request.Id);
                employeeDb.Address = request.Address;
                employeeDb.Name = request.Name;
                employeeDb.Phone = request.Phone;
                employeeDb.DofB = request.DofB;
                employeeDb.Email = request.Email;
                employeeDb.Department = request.Department;
                employeeDb.Sex = request.Sex;
                await _employeeRepository.Update(employeeDb);
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
