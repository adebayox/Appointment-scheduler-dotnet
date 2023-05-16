using System;
namespace Scheduler.Dtos.Appointment
{
	public class AddAppointmentDto
	{

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AppointmentTime { get; set; } = DateTime.Now;
    }
}

