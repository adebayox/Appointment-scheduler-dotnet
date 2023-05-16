using System;
using Scheduler.Dtos.Appointment;

namespace Scheduler.Services.AppointmentService
{
	public interface IAppointmentService
	{
        object Appointments { get; }

        Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments();

		Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int appointmentid);

        Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment);

        Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment);

        Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(int id);
    }
}

