using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scheduler.Authentication;
using Scheduler.Dtos.Appointment;
using Scheduler.Dtos.User;
using Scheduler.Model;
using Scheduler.Models;

namespace Scheduler.Services.AppointmentService
{
	public class AppointmentService : IAppointmentService
    {
      

        private static List<Appointment> appointments = new List<Appointment>
		{
			new Appointment(),
           
		};
		private readonly IMapper _mapper;
        private readonly IMailService _emailService;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentService(IMapper mapper, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IMailService emailService)
            
        
		{
			_mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        private string GetEmail() => (_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);


        public object Appointments => throw new NotImplementedException();

        public async Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment)
        {
			var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var appointment = _mapper.Map<Appointment>(newAppointment);
            appointment.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Send email to the user
          await  _emailService.SendEmail(newAppointment, GetEmail());

            serviceResponse.Data =
                await _context.Appointments
                .Where(c => c.User!.Id == GetUserId())
                .Select(c => _mapper.Map<GetAppointmentDto>(c))
                .ToListAsync();

            
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            try
            {
                var appointment = await _context.Appointments
                    .FirstOrDefaultAsync(c => c.AppointmentId == id && c.User!.Id == GetUserId());
                if (appointment is null)
                
                    throw new Exception($"Appointment with Id '{id}' not found.");

                    _context.Appointments.Remove(appointment);

                    await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Appointments
                    .Where(c => c.User!.Id == GetUserId())
                        .Select(c => _mapper.Map<GetAppointmentDto>(c)).ToListAsync();
                }
                catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments()
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var appointments = await _context.Appointments.Where(c => c.User!.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = appointments.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToList();
            return serviceResponse;


        }

        public async Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int appointmentid)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            var appointments = await _context.Appointments
                .FirstOrDefaultAsync(c => c.AppointmentId == appointmentid && c.User!.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetAppointmentDto>(appointments);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment)
        {
			var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            try
            {
                var appointment
                        = await _context.Appointments
                        .Include(c => c.User)
                        .FirstOrDefaultAsync(c => c.AppointmentId == updatedAppointment.AppointmentId);
                if (appointment is null || appointment.User!.Id != GetUserId())
                    throw new Exception($"Appointment with Id '{updatedAppointment.AppointmentId}'not found.");

                appointment.Title = updatedAppointment.Title;
                appointment.Description = updatedAppointment.Description;
                appointment.CreatedAt = updatedAppointment.CreatedAt;
                appointment.AppointmentTime = updatedAppointment.AppointmentTime;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetAppointmentDto>(appointment);
            }
        
                catch (Exception ex)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ex.Message;
                }
                return serviceResponse;
            }


    }
            }



