using System;
using MailKit;
using Scheduler.Dtos.Appointment;
using Scheduler.Dtos.User;
using Scheduler.Model;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Scheduler.Services
{
    public interface IMailService
    {
        Task SendEmail(AddAppointmentDto sendAppointment, string email);
    }

    public class SendGridMailService : IMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(AddAppointmentDto sendAppointment, string email)
        {
           
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("dadebayo200@gmail.com", "Appointment test");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(
                from, to,
                sendAppointment.AppointmentTime.ToString(),
                sendAppointment.Title,
                sendAppointment.Description);
            var response = await client.SendEmailAsync(msg);

        }


    }
}

