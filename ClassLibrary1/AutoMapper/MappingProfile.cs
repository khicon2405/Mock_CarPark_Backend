using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CoreApp.Data.Dto.Dto;
using CoreApp.Data.Dto.Request.Authentication;
using CoreApp.Data.Dto.Request.Car;
using CoreApp.Data.Dto.Request.Employee;
using CoreApp.Data.Dto.Request.Ticket;
using CoreApp.Data.Dto.Request.Trip;
using CoreApp.Data.Entity;

namespace CoreApp.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Map Employee
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<Employee, CreateEmployeeRequest>();
            CreateMap<CreateEmployeeRequest, Employee>();
            //End

            //Map Admin
            CreateMap<Admin, AdminDTO>();
            CreateMap<AdminDTO, Admin>();


            // End

             // Start Mapper Trip 
            CreateMap<Trip, TripDTO>();
            CreateMap<TripDTO, Trip>();

            CreateMap<Trip, CreateNewTripRequest>();
            CreateMap<CreateNewTripRequest, Trip>();
            // End Mapper Trip 

            CreateMap<Car, CarDTO>().
                ForMember(
                des => des.ParkName, act => act.MapFrom(src => src.ParkingLot.ParkName)
                );
            CreateMap<CarDTO, Car>();

            CreateMap<Car, CreateCarRequest>();
            CreateMap<CreateCarRequest, Car>();
            // End Mapper Car 

            // Start Mapper Parkinglot 
            /* CreateMap<Parkinglot, ParkinglotDto>();
             CreateMap<ParkinglotDto, Parkinglot>();*/

            /*CreateMap<Parkinglot, CreateParkinglotRequest>();
            CreateMap<CreateParkinglotRequest, Parkinglot>();*/
            // End Mapper Parkinglot 

            // Start Mapper Ticket 
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();

            CreateMap<Ticket, CreateNewTicketRequest>();
            CreateMap<CreateNewTicketRequest, Ticket>();
            // End Mapper Ticket 



            // Start Mapper BookingOffice 
            /*CreateMap<BookingOffice, BookingOfficeDto>();
            CreateMap<BookingOfficeDto, BookingOffice>();

            CreateMap<BookingOffice, CreateBookingOfficeRequest>();
            CreateMap<CreateBookingOfficeRequest, BookingOffice>();*/
            // End Mapper BookingOffice 
        }
    }
}
