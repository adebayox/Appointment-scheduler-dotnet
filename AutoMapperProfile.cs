using System;
using AutoMapper;
using Scheduler.Dtos.Appointment;
using Scheduler.Dtos.User;
using Scheduler.Model;

namespace Scheduler
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<Appointment, GetAppointmentDto>();

            CreateMap<AddAppointmentDto, Appointment>();

            CreateMap<UpdateAppointmentDto, Appointment>();

            CreateMap<UserRegisterDto, User>();
            
        }
    }
}

