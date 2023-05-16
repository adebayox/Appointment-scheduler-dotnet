using System;
namespace Scheduler.Dtos.Appointment
{
	public class UpdateAppointmentDto
	{
        public int AppointmentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AppointmentTime { get; set; } = DateTime.Now;
    }
}

