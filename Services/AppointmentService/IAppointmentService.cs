using System;
using System.Security.Claims;
using Scheduler.Dtos.Appointment;

namespace Scheduler.Services.AppointmentService
{
	public interface IAppointmentService
	{
        object Appointments { get; }

        Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments();

		Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int appointmentid);

        Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment);

        Task<ServiceResponse<List<GetAppointmentDto>>> GetRecentAppointments();


        Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment);

        Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(int id);
    }
}

