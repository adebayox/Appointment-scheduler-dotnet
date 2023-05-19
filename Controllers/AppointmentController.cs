using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Dtos.Appointment;
using Scheduler.Services.AppointmentService;

namespace Scheduler.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> Get()
        {
            return Ok(await _appointmentService.GetAllAppointments());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> Delete(int id)
        {
            var response = await _appointmentService.DeleteAppointment(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> GetSingle(int id)
        {
            return Ok(await _appointmentService.GetAppointmentById(id));
        }

        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> AddAppointment(AddAppointmentDto newAppointment)
        {
            
            return Ok(await _appointmentService.AddAppointment(newAppointment));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> UpdatedAppointment(UpdateAppointmentDto updatedAppointment)
        {
            var response = await _appointmentService.UpdateAppointment(updatedAppointment);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("recent-appointments")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> GetRecentAppointments()
        {
            // Call the GetRecentAppointments method from the service
            var serviceResponse = await _appointmentService.GetRecentAppointments();

            // Return the response
            return Ok(serviceResponse);
        }

    }
}
