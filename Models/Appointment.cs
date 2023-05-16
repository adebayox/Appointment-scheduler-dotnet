using System;
using Microsoft.EntityFrameworkCore;
using Scheduler.Authentication;

namespace Scheduler.Model
{
    public class Appointment
    {

        public int AppointmentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime AppointmentTime { get; set; } = DateTime.Now;

        public User? User { get; set; }

    }

}